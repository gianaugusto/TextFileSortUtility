using System;

namespace TestFileGenerator.Utils
{
    public static class ProgressReporter
    {
        public static void ReportProgress(int current, int total)
        {
            if (total <= 0) return;

            double progress = (double)current / total;
            int progressBarSize = 50;
            int progressBarFill = (int)(progress * progressBarSize);

            string progressBar = $"[{new string('#', progressBarFill)}{new string('-', progressBarSize - progressBarFill)}]";
            Console.Write($"\rProgress: {progressBar} {current}/{total} ({progress:P2})");

            if (current == total)
            {
                Console.WriteLine();
            }
        }
    }
}
