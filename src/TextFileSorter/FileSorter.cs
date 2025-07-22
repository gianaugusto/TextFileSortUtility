using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TextFileSorter
{

    public class FileSorter: IFileSorter
    {
        public static async Task SortLargeFileAsync(string inputFile, string outputFile, int chunkSizeInLines = 1000000)
        {
            var tempFiles = new List<string>();

            using var reader = new StreamReader(inputFile);
            while (!reader.EndOfStream)
            {
                var chunk = new List<(int, string)>(chunkSizeInLines);

                for (int i = 0; i < chunkSizeInLines && !reader.EndOfStream; i++)
                {
                    var line = await reader.ReadLineAsync();
                    var parts = line?.Split(new[] { ". " }, 2, StringSplitOptions.None);
                    if (parts?.Length == 2 && int.TryParse(parts[0], out int number))
                    {
                        chunk.Add((number, parts[1]));
                    }
                }

                var sortedChunk = chunk
                    .OrderBy(x => x.str)
                    .ThenBy(x => x.number)
                    .Select(x => $"{x.number}. {x.str}");

                string tempPath = Path.GetTempFileName();
                await File.WriteAllLinesAsync(tempPath, sortedChunk);
                tempFiles.Add(tempPath);
            }

            // Merge sorted files
            await MergeSortedFilesAsync(tempFiles, outputFile);

            // Cleanup
            foreach (var file in tempFiles)
            {
                File.Delete(file);
            }
        }

        private static async Task MergeSortedFilesAsync(List<string> sortedChunkFiles, string outputFile)
        {
            var readers = sortedChunkFiles.Select(f => new StreamReader(f)).ToList();
            var comparer = Comparer<(int, string)>.Create((a, b) =>
            {
                int strCmp = string.Compare(a.Item2, b.Item2, StringComparison.Ordinal);
                return strCmp != 0 ? strCmp : a.Item1.CompareTo(b.Item1);
            });

            var pq = new SortedDictionary<(int, string), int>(comparer);
            var currentLines = new (int, string)?[readers.Count];

            for (int i = 0; i < readers.Count; i++)
            {
                var line = await readers[i].ReadLineAsync();
                if (line != null)
                {
                    var parts = line.Split(new[] { ". " }, 2, StringSplitOptions.None);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int num))
                    {
                        var tuple = (num, parts[1]);
                        pq[tuple] = i;
                        currentLines[i] = tuple;
                    }
                }
            }

            using var writer = new StreamWriter(outputFile);
            while (pq.Count > 0)
            {
                var kvp = pq.First();
                pq.Remove(kvp.Key);

                await writer.WriteLineAsync($"{kvp.Key.Item1}. {kvp.Key.Item2}");

                int fileIndex = kvp.Value;
                var line = await readers[fileIndex].ReadLineAsync();
                if (line != null)
                {
                    var parts = line.Split(new[] { ". " }, 2, StringSplitOptions.None);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int num))
                    {
                        var tuple = (num, parts[1]);
                        pq[tuple] = fileIndex;
                    }
                }
            }

            foreach (var r in readers)
                r.Dispose();
        }
    }
}
