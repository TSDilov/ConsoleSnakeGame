using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMadness
{
    public class Printer
    {
        public static void PrintingTheSnake(Queue<Position> snakeElements)
        {
            foreach (var position in snakeElements)
            {
                Console.SetCursorPosition(position.Col, position.Row);
                Console.Write("*");
            }
        }

        public static void PrintingSnakeElement(Position position, string element)
        {
            Console.SetCursorPosition(position.Col, position.Row);
            Console.Write(element);
        }

        public static void PrintingTheSnakeFood(Position foodPosition)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(foodPosition.Col, foodPosition.Row);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public static void PrintingEmptyElement(Position lastPosition)
        {
            Console.SetCursorPosition(lastPosition.Col, lastPosition.Row);
            Console.Write(" ");
        }

        public static void PrintingGameOver()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Game over!");
        }

        public static void PrintingTheScore(Queue<Position> snakeElements)
        {
            Console.WriteLine($"Your point are: {(snakeElements.Count - 5) * 10}");
        }
    }
}
