using System;
using System.Collections.Generic;
using System.Management;
using CommandLine;
using ScapeChecker.Net.Exceptions;
using ScapeChecker.Net.Models;

namespace ScapeChecker.Net
{
    public class Runner
    {
        public static void RunOptions(Options opts)
        {
            try
            {
                var options = new ConnectionOptions();
                options.Impersonation = ImpersonationLevel.Impersonate;

                var scope = new ManagementScope($"\\\\{opts.MachineName}\\root\\cimv2", options);
                try
                {
                    scope.Connect();
                }
                catch (Exception ex)
                {
                    throw new ConnectionError(ex);
                }

                var query = new ObjectQuery($"SELECT * from Win32_Volume WHERE DriveLetter = '{opts.DriveName}:'");
                Win32Volume volumeInfo;
                using (var searcher = new ManagementObjectSearcher(scope, query))
                {
                    var results = new List<ManagementBaseObject>();
                    foreach (var managementBaseObject in searcher.Get())
                    {
                        results.Add(managementBaseObject);
                    }

                    if (results.Count != 1)
                    {
                        throw new DriveNotFoundException(opts.DriveName);
                    }

                    volumeInfo = new Win32Volume(results[0]);
                }

                var enoughSpace = EnoughRemaining(opts, volumeInfo);
                ConsoleReporter.PrintRemainingSpace(opts, volumeInfo, enoughSpace);
                NunitReporter.PrintRemainingSpace(opts, volumeInfo, enoughSpace);
                if (!enoughSpace)
                {
                    Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                ConsoleReporter.PrintStackTrace(opts, ex);
                NunitReporter.PrintStackTrace(opts, ex);
            }
        }

        public static void HandleParseError(IEnumerable<Error> errs)
        {
            Environment.Exit(1);
        }

        public static bool EnoughRemaining(Options opts, Win32Volume volume)
        {
            var wantedSize = SizeUnitHelper.AsBytes(opts.Unit, opts.Size);
            return wantedSize < volume.FreeSpace;
        }

        public string CheckAndParseDriveName(string driveName)
        {
            if (driveName.Length == 1 || driveName.Length == 2 && driveName[1] == ':')
            {
                var parsed = driveName[0].ToString().ToUpper();
                if (parsed[0] < 'A' || parsed[0] > 'Z')
                {
                    throw new InvalidDriveException(driveName);
                }

                return parsed;
            }

            throw new InvalidDriveException(driveName);
        }
    }
}