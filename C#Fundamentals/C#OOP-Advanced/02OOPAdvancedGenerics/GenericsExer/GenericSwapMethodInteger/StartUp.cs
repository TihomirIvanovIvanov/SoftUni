namespace GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var message = new List<int>();

            for (int i = 0; i < n; i++)
            {
                var items = int.Parse(Console.ReadLine());
                message.Add(items);
            }

            var indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var box = new Box<int>(message);
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}