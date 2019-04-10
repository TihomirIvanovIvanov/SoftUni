namespace BoxClass
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get => this.length;
            set => this.length = value;
        }

        public double Width
        {
            get => this.width;
            set => this.width = value;
        }

        public double Height
        {
            get => this.height;
            set => this.height = value;
        }

        public double SurfaceArea()
        {
            return 2 * (this.Length * this.Width) + 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }

        public double LateralSurface()
        {
            return 2 * (this.Length * this.Height) + 2 * (this.Width * this.Height);
        }

        public double Volume()
        {
            return this.Length * this.Width * this.Height;
        }
    }
}