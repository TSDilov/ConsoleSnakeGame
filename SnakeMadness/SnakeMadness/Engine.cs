using System;
using System.Collections.Generic;
using System.Linq;
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

        public Engine(Position[] directions, ref int direction, ref double sleepTime, ref Position foodPosition, Queue<Position> snakeElements)
        {
            this.directions = directions;
            this.direction = direction;
            this.sleepTime = sleepTime;
            this.foodPosition = foodPosition;
            this.snakeElements = snakeElements;
        }
        private static bool EndOfGame(Position snakeNewHead, Queue<Position> snakeElements)
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
                if (Engine.EndOfGame(snakeNewHead, snakeElements))
                {
                    return;
                }

                snakeElements.Enqueue(snakeNewHead);
                Printer.PrintingTheSnake(snakeElements);
                if (snakeNewHead.Col == foodPosition.Col && snakeNewHead.Row == foodPosition.Row)
                {
                    this.foodPosition = Helpers.FoodPosition();
                    Printer.PrintingTheSnakeFood(foodPosition);
                    this.sleepTime--;
                }
                else
                {
                    var last = snakeElements.Dequeue();
                    Printer.PrintingEmptyElement(last);
                }

                this.sleepTime -= 0.01;
                Thread.Sleep((int)this.sleepTime);
            }
        }
    }
}
