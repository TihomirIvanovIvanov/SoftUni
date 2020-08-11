using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var snake = Console.ReadLine();

            var target = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[sizes[0]][];

            GetMatrix(matrix, sizes[1], snake);

            Shoot(matrix, target);

            Collapse(matrix);

            PrintMatrix(matrix);
        }

        private static void Collapse(char[][] matrix)
        {
            var elements = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                var counter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                    else
                    {
                        counter++;
                    }
                }

                for (int row = 0; row < counter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = counter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }
            }
        }

        private static void Shoot(char[][] matrix, int[] target)
        {
            var targetRow = target[0];
            var targetCol = target[1];
            var radius = target[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var isInside = Math.Pow(targetRow - row, 2) + Math.Pow(targetCol - col, 2) <=
                                   Math.Pow(radius, 2);

                    if (isInside)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void GetMatrix(char[][] matrix, int col, string snake)
        {
            var counter = 0;
            var isLeft = true;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[col];

                if (isLeft)
                {
                    for (int cols = matrix[row].Length - 1; cols >= 0; cols--)
                    {
                        counter = SetLetter(matrix, snake, counter, row, cols);
                    }

                    isLeft = false;
                }
                else
                {
                    for (int cols = 0; cols < matrix[row].Length; cols++)
                    {
                        counter = SetLetter(matrix, snake, counter, row, cols);
                    }

                    isLeft = true;
                }
            }
        }

        private static int SetLetter(char[][] matrix, string snake, int counter, int row, int cols)
        {
            if (counter > snake.Length - 1)
            {
                counter = 0;
            }

            matrix[row][cols] = snake[counter];
            counter++;
            return counter;
        }
    }
}
