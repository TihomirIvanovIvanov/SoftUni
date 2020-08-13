using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            var operationsCount = int.Parse(Console.ReadLine());

            var numbers = new Stack<int>();

            for (int i = 0; i < operationsCount; i++)
            {
                var input = Console.ReadLine()
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

                var command = input[0];

                if (command == 1)
                {
                    var currentNumber = input[1];
                    numbers.Push(currentNumber);
                }
                else if (command == 2)
                {
                    numbers.Pop();
                }
                else if (command == 3)
                {
                    Console.WriteLine(numbers.Max());
                }
            }
        }
    }
}
