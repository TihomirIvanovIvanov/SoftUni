using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var values = input;
            var stack = new Stack<string>(values.Reverse());

            while (stack.Count > 1)
            {
                var first = int.Parse(stack.Pop());
                var @operator = stack.Pop();
                var second = int.Parse(stack.Pop());

                if (@operator == "+")
                {
                    stack.Push((first + second).ToString());
                }
                else
                {
                    stack.Push((first - second).ToString());
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
