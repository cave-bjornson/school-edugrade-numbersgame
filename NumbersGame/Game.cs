using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NumbersGameTests")]

namespace NumbersGame;


/// <summary>
/// Contains state and methods for the guessing game.
/// </summary>
internal class Game
{
    private const int Low = 1;
    private const int High = 20;
    private const int MaxTries = 5;
    private static readonly Random Rnd = new();

    public Game()
    {
        Tries = MaxTries;
        Number = Rnd.Next(Low, High);
    }

    public int Number { get; init; }
    public int Tries { get; private set; }

    /*
     * Returns true if guess is right. Prints different responses if
     * guess is right, lower or higher.
     */

    
    /// <summary>
    /// Checks if guess is right and outputs different responses
    /// depending on result.
    /// </summary>
    /// <param name="guess"> is the guessed number.</param>
    /// <returns><c>true</c> if guess is right.</returns>
    public bool CheckGuess(int guess)
    {
        Tries--;
        var diff = guess - Number;
        var message = diff switch
        {
            < 0 => "Sorry, you guessed too low!",
            > 0 => "Sorry, you guessed too high!",
            _ => "Wohoo! You made it!"
        };
        Console.WriteLine(message);
        return guess == Number;
    }


    /// <summary>
    /// Checks if any tries remaining and outputs
    /// a message if none remains.
    /// </summary>
    /// <returns><c>true</c> if remaining tries.</returns>
    public bool TriesRemain()
    {
        var triesRemain = Tries > 0;
        if (!triesRemain)
        {
            Console.WriteLine($"Sorry, you didn't guess the right number on {MaxTries} tries");
        }

        return triesRemain;
    }
}