using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    /// <summary>
    /// encapsulates the game logic for determining whether a guess is correct and whether the game is over
    /// </summary>
    public interface IHangmanGameLogic
    {
        bool IsCorrectGuess(string word, char letter);
        bool IsGameOver(int lives, string guess, string word);
    }
}
