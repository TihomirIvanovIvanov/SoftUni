using System;

public class Topping
{
    private const double Meat = 1.2;
    private const double Veggies = 0.8;
    private const double Cheese = 1.1;
    private const double Sauce = 0.9;
    private const double EachToppingCalories = 2;

    private string type;
    private double weight;

    public string Type
    {
        get { return this.type; }

        set
        {
            if (value != "meat" && value != "veggies" && value != "cheese" && value != "sauce")
            {
                var str = value[0].ToString().ToUpper() + value.Substring(1);
                throw new Exception($"Cannot place {str} on top of your pizza.");
            }
            this.type = value;
        }
    }

    public double Weight
    {
        get { return this.weight; }
        set
        {
            if (value < 1 || value > 50)
            {
                var str = this.type[0].ToString().ToUpper() + this.type.Substring(1);
                throw new Exception($"{str} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double Calories()
    {
        if (this.type == "meat")
        {
            return EachToppingCalories * Meat * this.weight;
        }
        else if (this.type == "veggies")
        {
            return EachToppingCalories * Veggies * this.weight;
        }
        else if (this.type == "cheese")
        {
            return EachToppingCalories * Cheese * this.weight;
        }
        else return EachToppingCalories * Sauce * this.weight;
    }
}