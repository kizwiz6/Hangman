using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGameLogic : IHangmanGameLogic
    {
        public bool IsCorrectGuess(string word, char letter)
        {
            return word.Contains(letter);
        }

        public bool IsGameOver(int lives, string guess, string word)
        {
            return lives <= 0 || guess == word;
        }
    }
}
