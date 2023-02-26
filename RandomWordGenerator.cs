using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class RandomWordGenerator : IWordGenerator
    {
        private readonly string[] _words = {"computer", "programmer", "software", "debugger", "compiler", "developer", "algorithm", "array", "method", "variable" };
        private readonly Random _random = new Random();

        public string GenerateWord()
        {
            return _words[_random.Next(_words.Length)];
        }
    }
}
