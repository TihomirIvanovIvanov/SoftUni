using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());

            var totalCells = 0;

            var firstMatrix = new int[rows][];
            var secondMatrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                firstMatrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                totalCells += firstMatrix[i].Length;
            }

            for (int i = 0; i < rows; i++)
            {
                secondMatrix[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Reverse()
                    .Select(int.Parse)
                    .ToArray();

                totalCells += secondMatrix[i].Length;
            }

            var colLength = firstMatrix[0].Length + secondMatrix[0].Length;
            var isFit = true;

            for (int i = 0; i < firstMatrix.Length; i++)
            {
                if (firstMatrix[i].Length + secondMatrix[i].Length != colLength)
                {
                    isFit = false;
                    break;
                }
            }

            if (isFit)
            {
                for (int i = 0; i < secondMatrix.Length; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstMatrix[i])}, {string.Join(", ", secondMatrix[i])}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }
    }
}
