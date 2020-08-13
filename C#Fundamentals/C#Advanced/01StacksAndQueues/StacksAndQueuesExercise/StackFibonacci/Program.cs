using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var fibonacci = new Stack<long>();

            fibonacci.Push(0);
            fibonacci.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                var firstNumber = fibonacci.Pop();
                var secondNumber = fibonacci.Peek();

                fibonacci.Push(firstNumber);
                fibonacci.Push(firstNumber + secondNumber);
            }

            Console.WriteLine(fibonacci.Peek());
        }
    }
}
