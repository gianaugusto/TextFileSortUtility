using System;
using System.Threading.Tasks;
using CommandLine;
using TestFileGenerator.Configuration;
using TestFileGenerator.Generation;
using TestFileGenerator.Utils;
using TestFileGenerator.Writing;

namespace TestFileGenerator
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
            ILineGenerator lineGenerator = new RandomLineGenerator(options.AverageLineSize);
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
