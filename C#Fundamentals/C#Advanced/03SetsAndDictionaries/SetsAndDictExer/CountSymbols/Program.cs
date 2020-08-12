using System;
using System.Collections.Generic;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var symbols = new SortedDictionary<char, int>();

            foreach (var currentCharacter in input)
            {
                if (!symbols.ContainsKey(currentCharacter))
                {
                    symbols.Add(currentCharacter, 0);
                }

                symbols[currentCharacter] += 1;
            }

            foreach (var item in symbols)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
