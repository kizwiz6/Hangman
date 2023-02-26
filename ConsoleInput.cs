using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    internal class ConsoleInput : IInputProvider
    {
        public char GetInput()
        {
            var input = Console.ReadKey(true).KeyChar;
            return char.ToLower(input);
        }
    }
}
