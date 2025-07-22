using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileSorter
{
    public class FileSorter
    {
        public static async Task SortFileAsync(string inputFile, string outputFile)
        {
            // Read all lines from the input file
            string[] lines = await File.ReadAllLinesAsync(inputFile);

            // Parse the lines into a list of tuples (number, string)
            List<(int number, string str)> parsedLines = new List<(int, string)>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(new[] { ". " }, 2, StringSplitOptions.None);
                if (parts.Length == 2)
                {
                    if (int.TryParse(parts[0], out int number))
                    {
                        parsedLines.Add((number, parts[1]));
                    }
                }
            }

            // Sort the lines first by string, then by number
            var sortedLines = parsedLines
                .OrderBy(x => x.str)
                .ThenBy(x => x.number)
                .Select(x => $"{x.number}. {x.str}")
                .ToList();

            // Write the sorted lines to the output file
            await File.WriteAllLinesAsync(outputFile, sortedLines);
        }
    }
}
