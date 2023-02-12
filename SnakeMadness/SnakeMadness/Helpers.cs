using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeMadness
{
    public class Helpers
    {
        public static Queue<Position> StartUpSnake(int numberOFCells)
        {
            var snakeElements = new Queue<Position>();
            for (int i = 0; i < numberOFCells; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            return snakeElements;
        }

        public static List<Position> GetObstacles()
        {
            var obstacles = new List<Position>();
            ObsticleWalls(obstacles);
            return obstacles;
        }

        
        public static Position[] Directions()
        {
            return new Position[]
            {
                new Position(0, 1),
                new Position(0, -1),
                new Position(1, 0),
                new Position(-1, 0),
            };
        }

        public static int DirectionSetting(ConsoleKeyInfo userInput, int direction)
        {
            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != 0) return 1;
                else return 0;
            }

            if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != 1) return 0;
                else return 1;
            }

            if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != 2) return 3;
                else return 2;
            }

            if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != 3) return 2;
                else return 3;
            }

            return -1;
        }

        public static Position FoodPosition()
        {
            var randomNumbersGenerator = new Random();
            var foodPosition = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight),
                randomNumbersGenerator.Next(0, Console.WindowWidth));

            return foodPosition;
        }

        private static void ObsticleWalls(List<Position> obstacles)
        {
            for (int i = 15; i < 52; i++)
            {
                obstacles.Add(new Position(8, i));
            }

            for (int i = 55; i < 63; i++)
            {
                obstacles.Add(new Position(8, i));
            }

            for (int i = 66; i < 105; i++)
            {
                obstacles.Add(new Position(8, i));
            }

            for (int i = 15; i < 58; i++)
            {
                obstacles.Add(new Position(20, i));
            }

            for (int i = 60; i < 105; i++)
            {
                obstacles.Add(new Position(20, i));
            }

            for (int i = 8; i < 14; i++)
            {
                obstacles.Add(new Position(i, 14));
            }

            for (int i = 15; i < 21; i++)
            {
                obstacles.Add(new Position(i, 14));
            }

            for (int i = 8; i < 13; i++)
            {
                obstacles.Add(new Position(i, 105));
            }

            for (int i = 16; i < 21; i++)
            {
                obstacles.Add(new Position(i, 105));
            }
        }

    }
}
