using System;
using System.Threading.Tasks;

namespace TestFileGenerator.Generation
{
    public class RandomLineGenerator : ILineGenerator
    {
        private readonly Random _random;
        private readonly int _averageLineSize;

        public RandomLineGenerator(int averageLineSize)
        {
            _random = new Random();
            _averageLineSize = averageLineSize;
        }

        public async Task<string> GenerateLineAsync()
        {
            // Simulate some work with async/await
            await Task.Delay(_random.Next(1, 10));

            // Generate a random string of the desired length
            int length = _random.Next(_averageLineSize / 2, _averageLineSize * 2);
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)_random.Next(32, 127); // Printable ASCII characters
            }

            return new string(chars);
        }
    }
}
