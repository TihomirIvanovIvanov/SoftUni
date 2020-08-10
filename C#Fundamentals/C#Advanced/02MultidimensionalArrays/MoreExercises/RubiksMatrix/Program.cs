using System;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            var rubikMatrix = new int[rows][];

            GetMatrix(rubikMatrix, cols);

            var commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var rowColIndex = int.Parse(input[0]);
                var direction = input[1];
                var moves = int.Parse(input[2]);

                if (direction == "down")
                {
                    MoveDown(rubikMatrix, rowColIndex, moves % rubikMatrix.Length);
                }
                else if (direction == "left")
                {
                    MoveLeft(rubikMatrix, rowColIndex, moves % rubikMatrix[0].Length);
                }
                else if (direction == "right")
                {
                    MoveRight(rubikMatrix, rowColIndex, moves % rubikMatrix[0].Length);
                }
                else if (direction == "up")
                {
                    MoveUp(rubikMatrix, rowColIndex, moves % rubikMatrix.Length);
                }
            }

            var counter = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                for (int col = 0; col < rubikMatrix.Length; col++)
                {
                    if (rubikMatrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");
                        counter++;
                    }
                    else
                    {
                        Rearrange(rubikMatrix, row, col, counter);
                        counter++;
                    }
                }
            }
        }

        private static void Rearrange(int[][] rubikMatrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < rubikMatrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < rubikMatrix[targetRow].Length; targetCol++)
                {
                    if (rubikMatrix[targetRow][targetCol] == counter)
                    {
                        rubikMatrix[targetRow][targetCol] = rubikMatrix[row][col];
                        rubikMatrix[row][col] = counter;
                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");
                        return;
                    }
                }
            }
        }

        private static void MoveUp(int[][] rubikMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                var firstElement = rubikMatrix[0][col];

                for (int row = 0; row < rubikMatrix.Length - 1; row++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row + 1][col];
                }

                rubikMatrix[rubikMatrix.Length - 1][col] = firstElement;
            }
        }

        private static void MoveRight(int[][] rubikMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                var lastElement = rubikMatrix[row][rubikMatrix[row].Length - 1];

                for (int col = rubikMatrix.Length - 1; col > 0; col--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col - 1];
                }

                rubikMatrix[row][0] = lastElement;
            }
        }

        private static void MoveLeft(int[][] rubikMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                var firstElement = rubikMatrix[row][0];

                for (int col = 0; col < rubikMatrix[row].Length - 1; col++)
                {
                    rubikMatrix[row][col] = rubikMatrix[row][col + 1];
                }

                rubikMatrix[row][rubikMatrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubikMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                var lastElement = rubikMatrix[rubikMatrix.Length - 1][col];

                for (int row = rubikMatrix.Length - 1; row > 0; row--)
                {
                    rubikMatrix[row][col] = rubikMatrix[row - 1][col];
                }

                rubikMatrix[0][col] = lastElement;
            }
        }

        private static void GetMatrix(int[][] rubikMatrix, int cols)
        {
            var counter = 1;

            for (int row = 0; row < rubikMatrix.Length; row++)
            {
                rubikMatrix[row] = new int[cols];

                for (int col = 0; col < rubikMatrix[row].Length; col++)
                {
                    rubikMatrix[row][col] = counter++;
                }
            }
        }
    }
}