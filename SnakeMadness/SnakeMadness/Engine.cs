using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMadness
{
    public class Engine
    {
        private readonly Position[] directions;
        private int direction;
        private double sleepTime;
        private Position foodPosition;
        private readonly Queue<Position> snakeElements;
        private readonly List<Position> obstacles;

        public Engine(Position[] directions, ref int direction, ref double sleepTime, Queue<Position> snakeElements, List<Position> obstacles)
        {
            this.directions = directions;
            this.direction = direction;
            this.sleepTime = sleepTime;
            this.foodPosition = Helpers.FoodPosition();
            this.snakeElements = snakeElements;
            this.obstacles = obstacles;
            Printer.PrintingTheSnakeFood(foodPosition);
            Printer.PrintingTheSnake(snakeElements);
            Printer.PrintingTheObstacles(obstacles);
        }
        private static bool EndOfGame(Position snakeNewHead, Queue<Position> snakeElements, List<Position> obstacles)
        {
            if (snakeElements.Contains(snakeNewHead) || obstacles.Contains(snakeNewHead))
            {
                Console.SetCursorPosition(0, 0);
                //Console.Clear();
                Printer.PrintingGameOver();
                Printer.PrintingTheScore(snakeElements);
                return true;
            }

            return false;
        }

        public void StartGame() 
        {
            while (true)
            {
                Console.CursorVisible = false;
                if (Console.KeyAvailable)
                {
                    var userInput = Console.ReadKey();
                    this.direction = Helpers.DirectionSetting(userInput, direction);
                }

                var snakeHead = snakeElements.Last();
                var nextDirection = directions[direction];
                var snakeNewHead = new Position(snakeHead.Row + nextDirection.Row,
                    snakeHead.Col + nextDirection.Col);

                if (snakeNewHead.Row < 0) snakeNewHead.Row = Console.WindowHeight - 1;
                if (snakeNewHead.Col < 0) snakeNewHead.Col = Console.WindowWidth - 1;
                if (snakeNewHead.Row >= Console.WindowHeight) snakeNewHead.Row = 0;
                if (snakeNewHead.Col >= Console.WindowWidth) snakeNewHead.Col = 0;

                if (EndOfGame(snakeNewHead, this.snakeElements, this.obstacles))
                {
                    return;
                }

                Printer.PrintingSnakeElement(snakeHead, "*");
                snakeElements.Enqueue(snakeNewHead);
                DirectionDefinitonOftheHead(snakeNewHead);

                if (snakeNewHead.Col == foodPosition.Col && snakeNewHead.Row == foodPosition.Row)
                {
                    do
                    {
                        this.foodPosition = Helpers.FoodPosition();
                    }
                    while (this.snakeElements.Contains(foodPosition) || this.obstacles.Contains(foodPosition));

                    Printer.PrintingTheSnakeFood(foodPosition);
                    this.sleepTime--;
                }
                else
                {
                    var last = snakeElements.Dequeue();
                    Printer.PrintingEmptyElement(last);
                }

                Printer.PrintingTheSnakeFood(foodPosition);
                this.sleepTime -= 0.01;
                Thread.Sleep((int)this.sleepTime);
            }
        }

        private void DirectionDefinitonOftheHead(Position snakeNewHead)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (this.direction == 0)
            {
                Printer.PrintingSnakeElement(snakeNewHead, ">");
            }
            else if (this.direction == 1)
            {
                Printer.PrintingSnakeElement(snakeNewHead, "<");
            }
            else if (this.direction == 3)
            {
                Printer.PrintingSnakeElement(snakeNewHead, "^");
            }
            else if (this.direction == 2)
            {
                Printer.PrintingSnakeElement(snakeNewHead, "v");
            }
        }
    }
}
