using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class ConsoleOutput : IOutputProvider
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
