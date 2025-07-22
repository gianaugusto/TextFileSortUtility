using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommandLine;
using TestFileCreator.Configuration;
using TestFileCreator.Generation;
using TestFileCreator.Utils;
using TestFileCreator.Writing;

namespace TestFileCreator
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            return await Parser.Default.ParseArguments<GeneratorOptions>(args)
                .MapResult(async options =>
                {
                    await GenerateFileAsync(options);
                    return 0;
                },
                errs => Task.FromResult(1));
        }

        private static async Task GenerateFileAsync(GeneratorOptions options)
        {
            // Generate a list of unique strings
            List<string> strings = new List<string>();
            for (int i = 1; i <= options.StringCount; i++)
            {
                strings.Add($"String{i}");
            }

            ILineGenerator lineGenerator = new TestFileLineGenerator(strings, options.MaxNumber);
            IFileWriter fileWriter = new BufferedFileWriter(options.OutputFile);

            try
            {
                for (int i = 0; i < options.NumberOfLines; i++)
                {
                    string line = await lineGenerator.GenerateLineAsync();
                    await fileWriter.WriteLineAsync(line);
                    ProgressReporter.ReportProgress(i + 1, options.NumberOfLines);
                }

                await fileWriter.FlushAsync();
                Console.WriteLine("File generation completed successfully.");
            }
            finally
            {
                fileWriter?.Dispose();
            }
        }
    }
}
