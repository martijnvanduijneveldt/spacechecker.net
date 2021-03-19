using System;
using ScapeChecker.Net.Models;

namespace ScapeChecker.Net
{
    public static class ConsoleReporter
    {
        public static void PrintRemainingSpace(Options opts, Win32Volume volume, bool enoughSpace)
        {
            Console.Out.WriteLine("Machine name    : " + opts.MachineName);
            Console.Out.WriteLine("Drive name      : " + volume.Name);
            Console.Out.WriteLine("Total space     : " + volume.Capacity.ToPrettySize());
            Console.Out.WriteLine("Available space : " + volume.FreeSpace.ToPrettySize());
            var asBytes = SizeUnitHelper.AsBytes(opts.Unit, opts.Size);
            Console.Out.WriteLine("Wanted space    : " + asBytes.ToPrettySize());

            var enough = enoughSpace ? "yes" : "no";
            Console.Out.WriteLine("Enough space    : " + enough);
        }
    }
}