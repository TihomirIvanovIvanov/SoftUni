using System;

namespace PointInRectangle
{
    public class StartUp
    {
        public static void Main()
        {
            var rect = new Rectangle(Console.ReadLine());

            var pointsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pointsCount; i++)
            {
                var point = new Point(Console.ReadLine);

                var containsPoint = rect.Contains(point);
                Console.WriteLine(containsPoint);
            }
        }
    }
}
