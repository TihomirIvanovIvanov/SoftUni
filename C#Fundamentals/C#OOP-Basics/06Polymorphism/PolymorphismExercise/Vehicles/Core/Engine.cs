namespace Vehicles.Core
{
    using System;
    using Vehicles;
    using Vehicles.Contracts;

    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var carFuelQuantity = double.Parse(carInfo[1]);
            var carFuelConsumption = double.Parse(carInfo[2]);

            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckFuelConsumption = double.Parse(truckInfo[2]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    var action = inputArgs[0];
                    var vehicleType = inputArgs[1];
                    var value = double.Parse(inputArgs[2]);

                    if (action == "Refuel")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Refuel(value);
                        }
                    }
                    else if (action == "Drive")
                    {
                        if (vehicleType == "Car")
                        {
                            car.Drive(value);
                        }
                        else if (vehicleType == "Truck")
                        {
                            truck.Drive(value);
                        }
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}