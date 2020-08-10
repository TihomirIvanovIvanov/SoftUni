using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new int[n][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var primarySum = int.MinValue;
            var secondarySym = int.MinValue;

            for (int i = 0; i < matrix.Length; i++)
            {
                primarySum += matrix[i][i];
                secondarySym += matrix[i][matrix.Length - 1 - i];
            }

            var result = Math.Abs(primarySum - secondarySym);
            Console.WriteLine(result);
        }
    }
}
