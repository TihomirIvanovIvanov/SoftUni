namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;

        private double width;

        private double height;

        private double x;

        private double y;

        public Rectangle(string id, double width, double height, double x, double y)
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.X = x;
            this.Y = y;
        }

        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public bool IsIntersect(Rectangle rectangle)
        {
            if (this.X + this.Width < rectangle.X ||
                rectangle.X + rectangle.Width < this.X ||
                this.Y + this.Height < rectangle.Y ||
                rectangle.Y + rectangle.Height < this.Y)
            {
                return false;
            }
            return true;
        }
    }
}
