using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var n = int.Parse(Console.ReadLine());

            numbers = Remove(numbers, n);
            numbers = Reverse(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static List<int> Reverse(List<int> numbers)
        {
            var reversed = new Stack<int>();
            foreach (var number in numbers)
            {
                reversed.Push(number);
            }
            return reversed.ToList();
        }

        private static List<int> Remove(List<int> numbers, int n)
        {
            Predicate<int> removeFunc = number => number % n != 0;
            return numbers.Where(x => removeFunc(x)).ToList();
        }
    }
}
