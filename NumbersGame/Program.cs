using Microsoft.Extensions.Logging;
using NumbersGame;

var loggerFactory = LoggerFactory.Create(
    builder => builder
        .AddDebug()
        .SetMinimumLevel(LogLevel.Debug)
);
var logger = loggerFactory.CreateLogger<Program>();


Game game = new();
logger.LogDebug("Right guess is: {number}", game.Number);
Console.WriteLine("Welcome! I'm thinking of a number between 1 and 20. Can you guess which number?");
Console.WriteLine("You get five tries.");


do
{
    Console.Write($"Tries left: {game.Tries}. Enter guess: ");
    int guess;
    while (!int.TryParse(Console.ReadLine(), out guess))
    {
        Console.Write("Enter an integer value: ");
    }

    if (game.CheckGuess(guess))
    {
        break;
    }
} while (game.TriesRemain());