using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var n = length[0];
            var m = length[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < m; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                secondSet.Add(currentNumber);
            }

            var intersectElements = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(' ', intersectElements));
        }
    }
}
