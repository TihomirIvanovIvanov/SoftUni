using System;
using System.Collections.Generic;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var left = int.Parse(input[0]);
            var right = int.Parse(input[1]);

            var parameter = Console.ReadLine();
            var numbers = new List<int>();

            var checkFunc = CreateFuntion(parameter);

            for (int i = left; i <= right; i++)
            {
                if (checkFunc(i))
                {
                    numbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }

        private static Predicate<int> CreateFuntion(string parameter)
        {
            if (parameter == "even")
            {
                return number => number % 2 == 0;
            }

            if (parameter == "odd")
            {
                return number => number % 2 != 0;
            }

            throw new Exception("Invalid parameter!");
        }
    }
}
