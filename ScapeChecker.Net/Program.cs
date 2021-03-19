using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using CommandLine;
using ScapeChecker.Net.Models;

namespace ScapeChecker.Net
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Runner.RunOptions)
                .WithNotParsed(Runner.HandleParseError);
        }
    }
}