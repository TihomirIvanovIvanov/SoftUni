using System;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var predicates = sequence
                .Select(number => (Predicate<int>)(x => x % int.Parse(number) == 0))
                .ToArray();

            for (int candidateNumber = 1; candidateNumber <= n; candidateNumber++)
            {
                var isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(candidateNumber))
                    {
                        isDivisible = false;
                        break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{candidateNumber} ");
                }
            }
        }
    }
}
