using Microsoft.Extensions.Logging;
using NumbersGame;

var loggerFactory = LoggerFactory.Create(
    builder => builder
        .AddDebug()
        .SetMinimumLevel(LogLevel.Debug)
);
var logger = loggerFactory.CreateLogger<Program>();


Game game = new();
Console.WriteLine("Welcome! I'm thinking of a number. Can you guess which number?");
Console.WriteLine("You get five tries.");
Console.Write($"Tries left: {game.Tries}. Enter guess: ");
int guess;
while (!int.TryParse(Console.ReadLine(), out guess)) Console.WriteLine("Enter an integer value: ");

game.CheckGuess(guess);