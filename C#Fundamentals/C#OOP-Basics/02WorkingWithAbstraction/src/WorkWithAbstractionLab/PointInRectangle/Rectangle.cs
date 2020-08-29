using System;
using System.Linq;

namespace PointInRectangle
{
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

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            return point.X >= this.TopLeft.X && point.X <= this.BottomRight.X &&
                   point.Y >= this.TopLeft.Y && point.Y <= this.BottomRight.Y;
        }
    }
}
