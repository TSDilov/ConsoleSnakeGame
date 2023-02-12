// See https://aka.ms/new-console-template for more information
using SnakeMadness;
using System.ComponentModel.DataAnnotations;
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
        var snakeElements = Helpers.StartUpSnake(numberOfStartElements);
        var obstacles = Helpers.GetObstacles();
        var gameEngine = new Engine(directions, ref direction, ref sleepTime, snakeElements, obstacles);
        gameEngine.StartGame();
    }
}