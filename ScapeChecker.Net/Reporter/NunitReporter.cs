using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using ScapeChecker.Net.Models;

namespace ScapeChecker.Net
{
    public class NunitReporter
    {
        public static string OptionsToString(Options opts)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Options :");
            stringBuilder.AppendLine("Machine name    : " + opts.MachineName);
            stringBuilder.AppendLine("Drive name      : " + opts.DriveName);
            var asBytes = SizeUnitHelper.AsBytes(opts.Unit, opts.Size);
            stringBuilder.AppendLine("Wanted space    : " + asBytes.ToPrettySize());
            return stringBuilder.ToString();
        }

        public static void PrintRemainingSpace(Options opts, Win32Volume volume, bool enoughSpace)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Machine name    : " + opts.MachineName);
            stringBuilder.AppendLine("Drive name      : " + volume.Name);
            stringBuilder.AppendLine("Total space     : " + volume.Capacity.ToPrettySize());
            stringBuilder.AppendLine("Available space : " + volume.FreeSpace.ToPrettySize());
            var asBytes = SizeUnitHelper.AsBytes(opts.Unit, opts.Size);
            stringBuilder.AppendLine("Wanted space    : " + asBytes.ToPrettySize());
            var enough = enoughSpace ? "yes" : "no";
            stringBuilder.AppendLine("Enough space    : " + enough);

            var testCase = new TestCase
            {
                Name = "CheckSpace_" + volume.DriveLetter,
                Time = 1,
                SystemOut = stringBuilder.ToString()
            };

            if (!enoughSpace)
            {
                testCase.NunitError = new NunitError
                {
                    Message = "Not enough space remaining"
                };
            }

            OutputAsFile(opts, testCase);
        }

        public static void PrintStackTrace(Options opts, Exception ex)
        {
            var testCase = new TestCase
            {
                Name = "CheckSpace",
                Time = 1,
                SystemOut = OptionsToString(opts),
                NunitError = new NunitError
                {
                    Content = ex.ToString(),
                },
            };
            OutputAsFile(opts, testCase);
        }

        public static void OutputAsFile(Options opts, TestCase testCase)
        {
            if (string.IsNullOrEmpty(opts.NUnitOuputFile))
            {
                return;
            }

            var parentFolder = Directory.GetParent(opts.NUnitOuputFile).ToString();
            if (!Directory.Exists(parentFolder))
            {
                Directory.CreateDirectory(parentFolder);
            }

            var xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");
            var x = new XmlSerializer(typeof(TestSuite));
            using (var writer = new StreamWriter(opts.NUnitOuputFile))
            {
                var testSuite = new TestSuite();
                testSuite.TestCases.Add(testCase);
                testSuite.Count = testSuite.TestCases.Count;
                x.Serialize(writer, testSuite, xmlnsEmpty);
            }
        }
    }
}