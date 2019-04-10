namespace PointInRectangle
{
    using System;
    using System.Linq;

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

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}