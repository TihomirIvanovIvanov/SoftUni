namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(int topX, int topY, int bottomX, int bottomY)
        {
            this.TopLeft = new Point(topX, topY);
            this.BottomRight = new Point(bottomX, bottomY);
        }

        public Rectangle(int[] coords)
            : this(coords[0], coords[1], coords[2], coords[3])
        {
        }

        public Rectangle(string coordsLine)
          : this(coordsLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
        {
        }

        public Point TopLeft
        {
            get { return this.topLeft; }
            set { this.topLeft = value; }
        }

        public Point BottomRight
        {
            get { return this.bottomRight; }
            set { this.bottomRight = value; }
        }

        public bool Contains(Point point)
        {
            return point.X >= TopLeft.X && point.X <= BottomRight.X &&
                   point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
        }
    }
}