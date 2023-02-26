using Hangman;

internal class Program
{
    public static void Main(string[] args)
    {
        var game = new HangmanGame(new ConsoleInput(), new ConsoleOutput(), new RandomWordGenerator(), new HangmanGameLogic());
        game.Run();
    }
}