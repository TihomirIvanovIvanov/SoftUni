using System;
using System.Collections.Generic;

namespace ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split();

            var stack = new Stack<string>(numbers);

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + ' ');
            }
            Console.WriteLine();
        }
    }
}
