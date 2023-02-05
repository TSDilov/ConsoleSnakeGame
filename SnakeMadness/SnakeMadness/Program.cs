﻿// See https://aka.ms/new-console-template for more information
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
        var sleepTime = 100;
        var foodPosition = Helpers.FoodPosition();

        var snakeElements = Helpers.StartUpSnake(numberOfStartElements);

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
            if (snakeNewHead.Col == foodPosition.Col && snakeNewHead.Row == foodPosition.Row)
            {
                foodPosition = Helpers.FoodPosition();
                sleepTime--;
            }
            else
            {
                snakeElements.Dequeue();
            }

            Console.Clear();
            Printer.PrintingTheSnake(snakeElements);
            Printer.PrintingTheSnakeFood(foodPosition);

            Thread.Sleep(sleepTime);
        }
    }
}