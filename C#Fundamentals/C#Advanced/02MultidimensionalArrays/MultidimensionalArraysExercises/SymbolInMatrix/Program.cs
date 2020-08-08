using System;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            //var n = int.Parse(Console.ReadLine());

            //var matrix = new char[n][];

            //for (int row = 0; row < matrix.Length; row++)
            //{
            //    matrix[row] = Console.ReadLine().ToCharArray();
            //}

            //var symbol = char.Parse(Console.ReadLine());

            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    for (int j = 0; j < matrix.Length; j++)
            //    {
            //        if (matrix[i][j] == symbol)
            //        {
            //            Console.WriteLine($"({i}, {j})");
            //            return;
            //        }
            //    }
            //}

            //Console.WriteLine($"{symbol} does not occur in the matrix");

            //// Task 5
            //var sizes = Console.ReadLine()
            //    .Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //var matrixx = new int[sizes[0], sizes[1]];

            //for (int row = 0; row < matrixx.GetLength(0); row++)
            //{
            //    var colElem = Console.ReadLine()
            //    .Split(',', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //    for (int col = 0; col < matrixx.GetLength(1); col++)
            //    {
            //        matrixx[row, col] = colElem[col];
            //    }
            //}

            //var maxSum = int.MinValue;
            //var rowIndex = int.MinValue;
            //var colIndex = int.MinValue;

            //for (int row = 0; row < matrixx.GetLength(0) - 1; row++)
            //{
            //    for (int col = 0; col < matrixx.GetLength(1) - 1; col++)
            //    {
            //        var sum = matrixx[row, col] +
            //                  matrixx[row, col + 1] +
            //                  matrixx[row + 1, col] +
            //                  matrixx[row + 1, col + 1];

            //        if (sum > maxSum)
            //        {
            //            maxSum = sum;
            //            rowIndex = row;
            //            colIndex = col;
            //        }
            //    }
            //}

            //for (int row = rowIndex; row < rowIndex + 2; row++)
            //{
            //    for (int col = colIndex; col < colIndex + 2; col++)
            //    {
            //        Console.Write($"{matrixx[row, col]} ");
            //    }
            //    Console.WriteLine();
            //}

            //Console.WriteLine(maxSum);


        }
    }
}
