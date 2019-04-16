using System;

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

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new Exception("Height cannot be zero or negative.");
            }
            this.height = value;
        }
    }
    public double SurfaceArea()
    {
        var result = 2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);
        return result;
    }
    public double LateralSurfaceArea()
    {
        var result = 2 * (this.length * this.height) + 2 * (this.width * this.height);
        return result;
    }
    public double Volume()
    {
        var result = this.length * this.width * this.height;
        return result;
    }
    public void Print()
    {
        Console.WriteLine($"Surface Area - {SurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {Volume():F2}");
    }
}