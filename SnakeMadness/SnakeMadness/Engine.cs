using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMadness
{
    public class Engine
    {
        public static bool EndOfGame(Position snakeNewHead, Queue<Position> snakeElements)
        {
            if (snakeNewHead.Row < 0
                || snakeNewHead.Col < 0
                || snakeNewHead.Row >= Console.WindowHeight
                || snakeNewHead.Col >= Console.WindowWidth
                || snakeElements.Contains(snakeNewHead))
            {
                Console.SetCursorPosition(0, 0);
                Console.Clear();
                Printer.PrintingGameOver();
                Printer.PrintingTheScore(snakeElements);
                return true;
            }

            return false;
        }
    }
}
