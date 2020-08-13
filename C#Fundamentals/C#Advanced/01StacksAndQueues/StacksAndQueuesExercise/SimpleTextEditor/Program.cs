using System;
using System.Collections.Generic;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var operationsCount = int.Parse(Console.ReadLine());

            var text = string.Empty;
            var stack = new Stack<string>();

            for (int i = 0; i < operationsCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var currentCommand = input[0];

                if (currentCommand == "1")
                {
                    var currentText = input[1];
                    stack.Push(text);

                    text += currentText;
                }
                else if (currentCommand == "2")
                {
                    var count = int.Parse(input[1]);

                    if (count > text.Length)
                    {
                        count = Math.Min(count, text.Length);
                    }

                    stack.Push(text);
                    text = text.Substring(0, text.Length - count);
                }
                else if (currentCommand == "3")
                {
                    var index = int.Parse(input[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (currentCommand == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}
