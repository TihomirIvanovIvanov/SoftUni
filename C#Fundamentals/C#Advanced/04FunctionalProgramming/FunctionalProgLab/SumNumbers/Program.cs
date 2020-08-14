using System;
using System.Linq;

namespace SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine();

            Func<string, int> count = x =>
                x.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Count();

            Func<string, int> sum = x =>
                x.Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Sum();

            Console.WriteLine(count(numbers));
            Console.WriteLine(sum(numbers));
        }
    }
}
