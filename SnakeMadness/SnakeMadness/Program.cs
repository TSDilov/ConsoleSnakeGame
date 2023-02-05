// See https://aka.ms/new-console-template for more information
using SnakeMadness;
using System.Runtime.CompilerServices;

var directions = Helpers.Directions;
int direction = 0;
var snakeElements = Helpers.StartUpSnake(5);

while (true)
{
    var userInput = Console.ReadKey();
	direction = Helpers.DirectionSetting(userInput);

    foreach (var position in snakeElements)
    {
        Console.SetCursorPosition(position.Col, position.Row);
        Console.Write("*");
    }
}
