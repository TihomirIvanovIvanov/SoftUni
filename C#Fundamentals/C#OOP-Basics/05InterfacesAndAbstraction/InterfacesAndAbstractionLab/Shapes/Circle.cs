namespace Shapes
{
    public class Circle : IDrawable
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get => this.radius;
            private set
            {
                this.radius = value;
            }
        }

        public void Draw()
        {
            var radiusIn = this.Radius - 0.4;
            var radiusOut = this.Radius + 0.4;

            for (double y = this.Radius; y >= -this.Radius - 1; --y)
            {
                for (double x = -this.Radius; x < radiusOut; x += 0.5)
                {
                    var value = x * x + y * y;

                    if (value >= radiusIn * radiusIn && value <= radiusOut * radiusOut)
                    {
                        System.Console.Write("*");
                    }
                    else
                    {
                        System.Console.Write(" ");
                    }
                }

                System.Console.WriteLine();
            }
        }
    }
}