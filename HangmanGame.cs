using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class HangmanGame
    {
        private readonly IInputProvider _inputProvider;
        private readonly IOutputProvider _outputProvider;
        private readonly IWordGenerator _wordGenerator;
        private readonly IHangmanGameLogic _gameLogic;

        public HangmanGame(IInputProvider inputProvider, IOutputProvider outputProvider, IWordGenerator wordGenerator, IHangmanGameLogic gameLogic)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
            _wordGenerator = wordGenerator;
            _gameLogic = gameLogic;
        }

        public void Run()
        {
            var word = _wordGenerator.GenerateWord();
            var guess = new char[word.Length];
            var lives = 6;
            var incorrectGuesses = new List<char>();

            for (int i = 0; i < guess.Length; i++)
            {
                guess[i] = '_';
            }

            _outputProvider.WriteLine("Welcome to Hangman! You have 6 lives to guess the word.");

            while (!_gameLogic.IsGameOver(lives, new string(guess), word))
            {
                _outputProvider.WriteLine("");
                _outputProvider.WriteLine($"Lives: {lives}");
                _outputProvider.WriteLine($"Incorrect guesses: {string.Join(", ", incorrectGuesses)}");
                _outputProvider.WriteLine($"Current guess: {new string(guess)}");

                var letter = _inputProvider.GetInput();

                if (!char.IsLetter(letter))
                {
                    _outputProvider.WriteLine("Please enter a letter.");
                    continue;
                }

                if (incorrectGuesses.Contains(letter) || new string(guess).Contains(letter))
                {
                    _outputProvider.WriteLine("You've already guessed that letter. Please try again.");
                    continue;
                }

                if (_gameLogic.IsCorrectGuess(word, letter))
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == letter)
                        {
                            guess[i] = letter;
                        }
                    }
                }
                else
                {
                    lives--;
                    incorrectGuesses.Add(letter);
                }
            }

            _outputProvider.WriteLine("");

            if (lives > 0)
            {
                _outputProvider.WriteLine($"Congratulations! You guessed the word {word} with {lives} lives remaining.");
            }
            else
            {
                _outputProvider.WriteLine($"Sorry, you ran out of lives. The word was {word}.");
            }
        }
    }
}
