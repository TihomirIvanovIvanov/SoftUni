namespace VehiclesExtension.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Vehicles.Contracts;
    using Vehicles;

    public class Engine
    {
        public void Run()
        {
            var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var carFuelQuantity = double.Parse(carInfo[1]);
            var carFuelConsumption = double.Parse(carInfo[2]);
            var carFuelTankCapacity = double.Parse(carInfo[3]);

            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckFuelConsumption = double.Parse(truckInfo[2]);
            var truckFuelTankCapacity = double.Parse(truckInfo[3]);

            var busFuelQuantity = double.Parse(busInfo[1]);
            var busFuelConsumption = double.Parse(busInfo[2]);
            var busFuelTankCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carFuelTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckFuelTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busFuelTankCapacity);

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
                        else if (vehicleType == "Bus")
                        {
                            bus.Refuel(value);
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
                        else if (vehicleType == "Bus")
                        {
                            bus.IsEmpty = false;
                            bus.Drive(value);
                        }
                    }
                    else if (action == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        bus.Drive(value);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}