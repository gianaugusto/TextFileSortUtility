using System;
using CommandLine;

namespace TextFileSorter.Configuration
{
    public class SorterOptions
    {
        [Option('i', "input", Required = true, HelpText = "Input file path")]
        public required string InputFile { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output file path")]
        public required string OutputFile { get; set; }
    }
}
