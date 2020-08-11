using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
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

            var matrix = new List<List<int>>();

            GetMatrix(matrix, rows, cols);

            string input;

            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var coordinates = input
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                var row = coordinates[0];
                var col = coordinates[1];
                var radius = coordinates[2];

                Attack(matrix, row, col, radius);
            }

            Print(matrix);
        }

        private static void Print(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }

        private static void Attack(List<List<int>> matrix, int row, int col, int radius)
        {
            for (int i = row - radius; i <= row + radius; i++)
            {
                if (IsInside(matrix, i, col))
                {
                    matrix[i][col] = 0;
                }
            }

            for (int j = col - radius; j <= col + radius; j++)
            {
                if (IsInside(matrix, row, j))
                {
                    matrix[row][j] = 0;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i].RemoveAll(x => x == 0);

                if (matrix[i].Count == 0)
                {
                    matrix.RemoveAt(i);
                    i--;
                }
            }
        }

        private static bool IsInside(List<List<int>> matrix, int row, int col)
        {
            return row >= 0 && row < matrix.Count &&
                   col >= 0 && col < matrix[row].Count;
        }

        private static void GetMatrix(List<List<int>> matrix, int rows, int cols)
        {
            var counter = 1;

            for (int i = 0; i < rows; i++)
            {
                var currentNumber = new List<int>();

                for (int j = 0; j < cols; j++)
                {
                    currentNumber.Add(counter++);
                }

                matrix.Add(currentNumber);
            }
        }
    }
}
