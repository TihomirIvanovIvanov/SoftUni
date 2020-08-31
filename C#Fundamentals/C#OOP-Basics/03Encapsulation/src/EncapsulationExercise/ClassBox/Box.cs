namespace ClassBox
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get => length; set => length = value; }

        public double Width { get => width; set => width = value; }

        public double Height { get => height; set => height = value; }

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
