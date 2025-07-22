using System;
using CommandLine;

namespace TestFileGenerator.Configuration
{
    public class GeneratorOptions
    {
        [Option('o', "output", Required = true, HelpText = "Output file path")]
        public required string OutputFile { get; set; }

        [Option('l', "lines", Required = false, HelpText = "Number of lines to generate", Default = 1000)]
        public int NumberOfLines { get; set; } = 1000;

        [Option('s', "line-size", Required = false, HelpText = "Average line size in bytes", Default = 100)]
        public int AverageLineSize { get; set; } = 100;
    }
}
