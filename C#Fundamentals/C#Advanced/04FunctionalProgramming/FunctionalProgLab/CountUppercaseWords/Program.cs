using System;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpperCase = x => char.IsUpper(x[0]);
            Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpperCase)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
