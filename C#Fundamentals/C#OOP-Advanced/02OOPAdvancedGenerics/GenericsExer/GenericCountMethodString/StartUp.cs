namespace GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

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

            var element = Console.ReadLine();

            var box = new Box<string>(message);
            var result = box.GetGreaterThan(element);
            Console.WriteLine(result);
        }
    }
}