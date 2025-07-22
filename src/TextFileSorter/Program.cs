using System;
using System.Threading.Tasks;
using CommandLine;
using TextFileSorter.Configuration;

namespace TextFileSorter
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            return await Parser.Default.ParseArguments<SorterOptions>(args)
                .MapResult(async options =>
                {
                    await SortFileAsync(options);
                    return 0;
                },
                errs => Task.FromResult(1));
        }

        private static async Task SortFileAsync(SorterOptions options)
        {
            IFileSorter fileSorter = new FileSorter();
            try
            {
                await fileSorter.SortFileAsync(options.InputFile, options.OutputFile);
                Console.WriteLine("File sorting completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sorting file: {ex.Message}");
                return;
            }
        }
    }
}
