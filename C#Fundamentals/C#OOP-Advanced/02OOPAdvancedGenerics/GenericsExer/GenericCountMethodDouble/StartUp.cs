namespace GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var message = new List<double>();

            for (int i = 0; i < n; i++)
            {
                var items = double.Parse(Console.ReadLine());
                message.Add(items);
            }

            var element = double.Parse(Console.ReadLine());

            var box = new Box<double>(message);
            var result = box.GetGreaterThan(element);
            Console.WriteLine(result);
        }
    }
}