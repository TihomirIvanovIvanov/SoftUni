using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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

            var queueOfNumbers = new Queue<int>();

            for (int i = 0; i < toPush && i < numbers.Length; i++)
            {
                queueOfNumbers.Enqueue(numbers[i]);
            }

            for (int i = 0; i < toPop && queueOfNumbers.Count > 0; i++)
            {
                queueOfNumbers.Dequeue();
            }

            if (queueOfNumbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queueOfNumbers.Contains(magicNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queueOfNumbers.Min());
            }
        }
    }
}
