using System;
using System.Collections.Generic;

namespace DecimalToBinaryConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var @decimal = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            if (@decimal == 0)
            {
                Console.WriteLine(0);
            }

            while (@decimal != 0)
            {
                stack.Push(@decimal % 2);
                @decimal /= 2;
            }

            while (stack.Count != 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
