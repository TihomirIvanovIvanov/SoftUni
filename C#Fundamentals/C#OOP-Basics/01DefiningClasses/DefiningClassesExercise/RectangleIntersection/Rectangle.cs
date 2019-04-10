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

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public double Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        public double Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        internal bool Intersect(Rectangle secondRectangle)
        {
            if (this.X + this.Width < secondRectangle.X ||
                secondRectangle.X + secondRectangle.Width < this.X ||
                this.Y + this.Height < secondRectangle.Y ||
                secondRectangle.Y + secondRectangle.Height < this.Y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //private string id;
        //private double width;
        //private double height;
        //private double topLeftX;
        //private double topLeftY;

        //public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
        //{
        //    this.Id = id;
        //    this.Width = width;
        //    this.Height = height;
        //    this.TopLeftX = topLeftX;
        //    this.TopLeftY = topLeftY;
        //}

        //public string Id
        //{
        //    get { return this.id; }
        //    set { this.id = value; }
        //}

        //public double Width
        //{
        //    get { return this.width; }
        //    set { this.width = value; }
        //}

        //public double Height
        //{
        //    get { return this.height; }
        //    set { this.height = value; }
        //}

        //public double TopLeftX
        //{
        //    get { return this.topLeftX; }
        //    set { this.topLeftX = value; }
        //}

        //public double TopLeftY
        //{
        //    get { return this.topLeftY; }
        //    set { this.topLeftY = value; }
        //}

        //public bool DoIntersectWith(Rectangle r2)
        //{
        //    if (this.TopLeftX > r2.TopLeftX + r2.Width || r2.TopLeftX > this.TopLeftX + this.Width)
        //    {
        //        return false;
        //    }

        //    if (this.TopLeftY < r2.TopLeftY - this.Height || r2.TopLeftY < this.TopLeftY - this.Height)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}