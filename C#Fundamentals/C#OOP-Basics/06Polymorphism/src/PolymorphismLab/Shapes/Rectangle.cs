using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;

        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get => this.width;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException(nameof(this.Width), "Cannot be zero or negative!");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException(nameof(this.Height), "Cannot be zero or negative!");
                }
                this.height = value;
            }
        }

        public override double CalculateArea()
        {
            return this.Width * this.Height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.Width + 2 * this.Height;
        }

        public override string Draw()
        {
            return base.Draw() + this.GetType().Name;
        }
    }
}
