namespace VehiclesExtension.Vehicles
{
    using System;

    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += airConditionConsumption;
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);

            this.FuelQuantity += fuel * 0.95;
        }
    }
}