using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var operations = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var toPush = operations[0];
            var toPop = operations[1];
            var magicNumber = operations[2];

            var stackOfNumbers = new Stack<int>();

            for (int i = 0; i < toPush && i < numbers.Length; i++)
            {
                stackOfNumbers.Push(numbers[i]);
            }

            for (int i = 0; i < toPop && stackOfNumbers.Count > 0; i++)
            {
                stackOfNumbers.Pop();
            }

            if (stackOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stackOfNumbers.Contains(magicNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stackOfNumbers.Min());
            }
        }
    }
}
