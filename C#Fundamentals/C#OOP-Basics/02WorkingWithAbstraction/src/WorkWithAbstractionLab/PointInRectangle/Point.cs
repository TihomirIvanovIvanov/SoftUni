using System;
using System.Linq;

namespace PointInRectangle
{
    public class Point
    {
        private int x;

        private int y;

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point(Func<string> readsPoint)
        {
            var pointsCoordinates = readsPoint()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            this.X = pointsCoordinates[0];
            this.Y = pointsCoordinates[1];
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
