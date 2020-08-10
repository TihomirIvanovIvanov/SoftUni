using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = sizes[0];
            var col = sizes[1];

            var matrix = new string[row][];
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new string[col];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    var firstLetter = alphabet[i];
                    var middleLetter = alphabet[i + j];

                    matrix[i][j] = $"{firstLetter}{middleLetter}{firstLetter}";

                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
