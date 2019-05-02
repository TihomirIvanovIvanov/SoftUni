namespace GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var message = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var items = Console.ReadLine();
                message.Add(items);
            }

            var indexes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var box = new Box<string>(message);
            box.Swap(indexes[0], indexes[1]);
            Console.WriteLine(box);
        }
    }
}
