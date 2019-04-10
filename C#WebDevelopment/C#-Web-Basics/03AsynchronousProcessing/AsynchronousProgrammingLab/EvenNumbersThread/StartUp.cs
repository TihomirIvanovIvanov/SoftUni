namespace EvenNumbersThread
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            var numbersRange = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Thread evens = new Thread(() => PrintEvenNumbers(numbersRange));
            evens.Start();
            evens.Join();
            Console.WriteLine("Thread finished work!");
        }

        private static void PrintEvenNumbers(List<int> numbers)
        {
            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
