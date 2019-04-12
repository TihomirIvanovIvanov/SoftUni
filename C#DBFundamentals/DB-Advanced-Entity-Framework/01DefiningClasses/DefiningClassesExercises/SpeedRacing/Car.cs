using System;

public class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public double DistanceTravel { get; set; }

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelConsumption;
        this.DistanceTravel = 0;
    }

    public void Drive(double km)
    {
        var maxDistance = this.FuelAmount / this.FuelConsumption;
        if (km > maxDistance)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.DistanceTravel += km;
            this.FuelAmount -= this.FuelConsumption * km;
        }
    }
}