using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NumbersGameTests")]

namespace NumbersGame;

internal class Game
{
    private const int Low = 1;
    private const int High = 20;
    private const int MaxTries = 5;
    private static readonly Random Rnd = new();

    public Game()
    {
        Tries = 0;
        Number = Rnd.Next(Low, High);
    }

    public int Number { get; init; }
    public int Tries { get; private set; }

    /*
     * Returns true if guess is right. Prints different responses if
     * guess is right, lower or higher.
     */
    public bool CheckGuess(int guess)
    {
        Tries++;
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

    public bool TriesRemain()
    {
        var triesRemain = Tries <= MaxTries;
        if (!triesRemain)
        {
            Console.WriteLine($"Sorry, you didn't guess the right number on {MaxTries} tries");
        }

        return triesRemain;
    }
}