namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var operations = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rectanglesCount = operations[0];
            var intersectionCount = operations[1];

            var rectangles = new List<Rectangle>();

            for (int i = 0; i < rectanglesCount; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

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
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var firstId = input[0];
                var secondId = input[1];

                var firstRectangle = rectangles
                    .FirstOrDefault(r => r.Id == firstId);

                var secondRectangle = rectangles
                    .FirstOrDefault(r => r.Id == secondId);

                if (firstRectangle.Intersect(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }

            //var args = Console.ReadLine()
            //    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            //    .Select(int.Parse)
            //    .ToArray();

            //var rectanglesCount = args[0];
            //var checksCount = args[1];

            //var rectangles = new List<Rectangle>();

            //for (int i = 0; i < rectanglesCount; i++)
            //{
            //    var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    var id = input[0];
            //    var width = double.Parse(input[1]);
            //    var height = double.Parse(input[2]);
            //    var topLeftX = double.Parse(input[3]);
            //    var topLeftY = double.Parse(input[4]);

            //    var currentRectangle = new Rectangle(id, width, height, topLeftX, topLeftY);
            //    rectangles.Add(currentRectangle);
            //}

            //for (int i = 0; i < checksCount; i++)
            //{
            //    var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    var r1 = rectangles
            //        .FirstOrDefault(r => r.Id == input[0]);

            //    var r2 = rectangles
            //        .FirstOrDefault(r => r.Id == input[1]);

            //    Console.WriteLine(r1.DoIntersectWith(r2).ToString().ToLower());
            //}
        }
    }
}