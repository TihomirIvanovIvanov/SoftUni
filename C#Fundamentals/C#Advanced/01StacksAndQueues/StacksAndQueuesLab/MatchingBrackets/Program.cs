using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var finder = new Stack<int>(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    finder.Push(i);
                }
                else if (input[i] == ')')
                {
                    var start = finder.Pop();
                    Console.WriteLine(input.Substring(start, i - start + 1));
                }
            }
        }
    }
}
