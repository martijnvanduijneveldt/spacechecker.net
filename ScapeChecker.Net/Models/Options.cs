using CommandLine;

namespace ScapeChecker.Net.Models
{
    public class Options
    {
        [Option('d', "drive", Required = true, HelpText = "Drive name of which you want to check available space")]
        public string DriveName { get; set; }

        [Option('m', "machinename", Required = true,
            HelpText = "Machine on which you want to check space : \".\" for localhost")]
        public string MachineName { get; set; }

        [Option('u', "unit", Required = true, HelpText = "Unit in which to compare size : B, KB, MB, GB, TB")]
        public SizeUnit Unit { get; set; }

        [Option('s', "size", Required = true, HelpText = "Minimal size you want to have on share")]
        public uint Size { get; set; }

        [Option( "nunitoutput", Required = false, HelpText = "Output file for nunit reporter")]
        public string NUnitOuputFile { get; set; }
    }
}