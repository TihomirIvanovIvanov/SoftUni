using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var elements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentElem = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var elem in currentElem)
                {
                    elements.Add(elem);
                }
            }

            Console.WriteLine(string.Join(' ', elements));
        }
    }
}
