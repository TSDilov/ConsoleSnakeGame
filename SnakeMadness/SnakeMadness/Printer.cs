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
    }
}
