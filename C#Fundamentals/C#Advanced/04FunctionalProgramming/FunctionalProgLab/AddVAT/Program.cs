using System;
using System.Linq;

namespace AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => double.Parse(x) * 1.2)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
