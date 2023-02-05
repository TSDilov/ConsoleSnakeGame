// See https://aka.ms/new-console-template for more information
using SnakeMadness;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        var directions = Helpers.Directions();
        int direction = 0;
        var snakeElements = Helpers.StartUpSnake(5);

        Printer.PrintingTheSnake(snakeElements);

        while (true)
        {
            var userInput = Console.ReadKey();
            direction = Helpers.DirectionSetting(userInput);


            var snakeHead = snakeElements.Last();
            snakeElements.Dequeue();
            var nextDirection = directions[direction];
            var snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                snakeHead.Col + nextDirection.Col);
            snakeElements.Enqueue(snakeNewHead);

            Console.Clear();
            Printer.PrintingTheSnake(snakeElements);
        }
    }
}