using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string line;

            while ((line = Console.ReadLine()) != "end")
            {
                switch (line)
                {
                    case "add": Add(numbers); break;
                    case "subtract": Subtract(numbers); break;
                    case "multiply": Multiply(numbers); break;
                    case "print": Print(numbers); break;
                }
            }
        }

        private static void Print(List<int> numbers)
        {
            Console.WriteLine(string.Join(' ', numbers));
        }

        private static void Multiply(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= 2;
            }
        }

        private static void Subtract(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

        private static void Add(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]++;
            }
        }
    }
}
