// See https://aka.ms/new-console-template for more information
using SnakeMadness;
using System.Runtime.CompilerServices;

internal class Program
{
    private const int numberOfStartElements = 5;
    private static void Main(string[] args)
    {
        Console.BufferHeight = Console.WindowHeight;
        var directions = Helpers.Directions();
        var direction = 0;
        double sleepTime = 100;
        var foodPosition = Helpers.FoodPosition();

        var snakeElements = Helpers.StartUpSnake(numberOfStartElements);
        Printer.PrintingTheSnakeFood(foodPosition);
        Printer.PrintingTheSnake(snakeElements);

        while (true)
        {
            Console.CursorVisible = false;
            if (Console.KeyAvailable)
            {
                var userInput = Console.ReadKey();
                direction = Helpers.DirectionSetting(userInput, direction);
            }

            var snakeHead = snakeElements.Last();
            var nextDirection = directions[direction];
            var snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                snakeHead.Col + nextDirection.Col);
            if (Engine.EndOfGame(snakeNewHead, snakeElements))
            {
                return;
            }

            snakeElements.Enqueue(snakeNewHead);
            Printer.PrintingTheSnake(snakeElements);
            if (snakeNewHead.Col == foodPosition.Col && snakeNewHead.Row == foodPosition.Row)
            {
                foodPosition = Helpers.FoodPosition();
                Printer.PrintingTheSnakeFood(foodPosition);
                sleepTime--;
            }
            else
            {
                var last = snakeElements.Dequeue();
                Printer.PrintingEmptyElement(last);
            }

            /*Printer.PrintingTheSnake(snakeElements);
            Printer.PrintingTheSnakeFood(foodPosition);*/

            sleepTime -= 0.01;
            Thread.Sleep((int)sleepTime);
        }
    }
}