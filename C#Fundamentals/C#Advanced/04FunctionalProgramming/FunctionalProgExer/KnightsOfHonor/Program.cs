using System;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = inputString =>
            {
                var collection = inputString
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(string.Join(Environment.NewLine, collection.Select(x => $"Sir {x}")));
            };
            print(Console.ReadLine());
        }
    }
}
