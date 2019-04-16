using System;

public class Box
{
    private double lenght;
    private double width;
    private double height;

    public Box(double lenght, double width, double height)
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;
    }

    public double Lenght
    {
        get { return this.lenght; }
        set { this.lenght = value; }
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
    public double GetSurfaceArea()
    {
        var result = 2 * (this.lenght * this.width) + 2 * (this.lenght * this.height) + 2 * (this.width * this.height);
        return result;
    }
    public double GetLateralSurfaceArea()
    {
        var result = 2 * (this.lenght * this.height) + 2 * (this.width * this.height);
        return result;
    }
    public double GetVolume()
    {
        var result = this.lenght * this.width * this.height;
        return result;
    }

    public void Print()
    {
        Console.WriteLine($"Surface Area - {GetSurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {GetLateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {GetVolume():F2}");
    }
}
