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

        public static void PrintingTheSnakeFood(Position foodPosition)
        {
            Console.SetCursorPosition(foodPosition.Col, foodPosition.Row);
            Console.Write("@");
        }
    }
}
