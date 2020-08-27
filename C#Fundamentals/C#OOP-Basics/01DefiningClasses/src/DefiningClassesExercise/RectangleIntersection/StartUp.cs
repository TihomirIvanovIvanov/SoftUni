using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class StartUp
    {
        public static void Main()
        {
            var operations = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rectCount = operations[0];
            var intersectionCount = operations[1];

            var rectangles = new List<Rectangle>();

            for (int i = 0; i < rectCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = input[0];
                var width = double.Parse(input[1]);
                var height = double.Parse(input[2]);
                var x = double.Parse(input[3]);
                var y = double.Parse(input[4]);

                var rectangle = new Rectangle(name, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < intersectionCount; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var firstId = input[0];
                var secondId = input[1];

                var firstRect = rectangles
                    .FirstOrDefault(r => r.Id == firstId);

                var secondRect = rectangles
                    .FirstOrDefault(r => r.Id == secondId);

                if (firstRect.IsIntersect(secondRect))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
