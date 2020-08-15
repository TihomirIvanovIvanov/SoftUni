using System;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Predicate<string> checkName = name => name.Length <= length;
            var result = names.Where(name => checkName(name));
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
