using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var indexes = new List<int>();

            var days = 0;

            while (true)
            {
                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        indexes.Add(i + 1);
                    }
                }

                if (indexes.Count == 0)
                {
                    break;
                }

                var counter = 0;

                for (int i = 0; i < indexes.Count; i++)
                {
                    plants.RemoveAt(indexes[i] - counter);
                    counter++;
                }

                days++;
                indexes.Clear();
            }

            Console.WriteLine(days);
        }
    }
}
