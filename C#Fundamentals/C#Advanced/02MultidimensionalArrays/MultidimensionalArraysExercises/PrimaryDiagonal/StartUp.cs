using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var colElements = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            var primarySum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                primarySum += matrix[row, row];
            }

            Console.WriteLine(primarySum);
        }
    }
}
