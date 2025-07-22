using System;
using CommandLine;

namespace TestFileCreator.Configuration
{
    public class GeneratorOptions
    {
        [Option('o', "output", Required = true, HelpText = "Output file path")]
        public required string OutputFile { get; set; }

        [Option('n', "number", Required = false, HelpText = "Number of lines to generate", Default = 1000)]
        public int NumberOfLines { get; set; } = 1000;

        [Option('s', "string-count", Required = false, HelpText = "Number of different strings to use", Default = 10)]
        public int StringCount { get; set; } = 10;

        [Option('m', "max-number", Required = false, HelpText = "Maximum number value", Default = 10000)]
        public int MaxNumber { get; set; } = 10000;
    }
}
