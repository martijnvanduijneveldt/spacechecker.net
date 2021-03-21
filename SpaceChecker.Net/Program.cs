using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using CommandLine;
using SpaceChecker.Net.Models;

namespace SpaceChecker.Net
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