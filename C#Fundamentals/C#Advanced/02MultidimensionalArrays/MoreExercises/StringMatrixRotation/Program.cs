using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text.RegularExpressions;
using System.Threading.Tasks.Dataflow;

namespace StringMatrixRotation
{
    class Program
    {
        static char[][] matrix;

        static List<string> words;

        static void Main(string[] args)
        {
            var rotate = Console.ReadLine();
            var pattern = @"(\d+)";
            var degree = int.Parse(Regex.Match(rotate, pattern).Groups[1].Value);
            degree %= 360;

            words = new List<string>();
            var word = Console.ReadLine();

            while (word != "END")
            {
                words.Add(word);
                word = Console.ReadLine();
            }

            var rows = words.Count();
            var cols = words.Max(w => w.Length);

            matrix = new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[cols];

                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (j <= words[i].Length - 1)
                    {
                        matrix[i][j] = words[i][j];
                    }
                    else
                    {
                        matrix[i][j] = ' ';
                    }
                }
            }

            if (degree == 90)
            {
                matrix = MatrixRotate90(rows, cols);
            }
            if (degree == 180)
            {
                matrix = MatrixRotate180(rows, cols);
            }
            if (degree == 270)
            {
                matrix = MatrixRotate270(rows, cols);
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(string.Empty, row));
            }
        }

        private static char[][] MatrixRotate270(int rows, int cols)
        {
            var newMatrix = new char[cols][];

            for (int colIndex = cols; colIndex > 0; colIndex--)
            {
                var currentArray = new char[rows];
                for (int rowIndex = rows; rowIndex > 0; rowIndex--)
                {
                    currentArray[Math.Abs(rowIndex - rows)] = matrix[Math.Abs(rowIndex - rows)][colIndex - 1];
                }
                newMatrix[Math.Abs(colIndex - cols)] = currentArray;
            }

            return newMatrix;
        }

        private static char[][] MatrixRotate180(int rows, int cols)
        {
            var newMatrix = new char[rows][];

            for (int rowIndex = rows; rowIndex > 0; rowIndex--)
            {
                var currentArray = new char[cols];
                for (int colIndex = cols; colIndex > 0; colIndex--)
                {
                    currentArray[Math.Abs(colIndex - cols)] = matrix[rowIndex - 1][colIndex - 1];
                }
                newMatrix[Math.Abs(rowIndex - rows)] = currentArray;
            }

            return newMatrix;
        }

        private static char[][] MatrixRotate90(int rows, int cols)
        {
            var newMatrix = new char[cols][];

            for (int colIndex = cols; colIndex > 0; colIndex--)
            {
                var currentArray = new char[rows];
                for (int rowIndex = rows; rowIndex > 0; rowIndex--)
                {
                    currentArray[Math.Abs(rowIndex - rows)] = matrix[rowIndex - 1][Math.Abs(colIndex - cols)];
                }
                newMatrix[Math.Abs(colIndex - cols)] = currentArray;
            }

            return newMatrix;
        }
    }
}
