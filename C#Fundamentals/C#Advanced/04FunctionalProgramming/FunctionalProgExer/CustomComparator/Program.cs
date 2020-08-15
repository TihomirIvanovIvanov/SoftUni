using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var evenOddComparator = new EvenOddComparer();
            Array.Sort(numbers, evenOddComparator);
            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}
