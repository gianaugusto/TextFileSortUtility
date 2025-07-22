using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestFileCreator.Generation
{
    public class TestFileLineGenerator : ILineGenerator
    {
        private readonly Random _random;
        private readonly List<string> _strings;
        private readonly int _maxNumber;

        public TestFileLineGenerator(List<string> strings, int maxNumber)
        {
            _random = new Random();
            _strings = strings;
            _maxNumber = maxNumber;
        }

        public async Task<string> GenerateLineAsync()
        {
            // Simulate some work with async/await
            await Task.Delay(_random.Next(1, 10));

            // Generate a random number
            int number = _random.Next(1, _maxNumber + 1);

            // Choose a random string
            string str = _strings[_random.Next(_strings.Count)];

            return $"{number}. {str}";
        }
    }
}
