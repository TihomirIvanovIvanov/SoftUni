using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public  class StartUp
    {
        public  static void Main()
        {
            List<Car> carList = new List<Car>();
            HashSet<string> uniqeModels = new HashSet<string>();
            int n = int.Parse(Console.ReadLine().Trim());
            string model = String.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (!uniqeModels.Contains(inputArgs[0]))
                {
                    model = inputArgs[0];
                    uniqeModels.Add(inputArgs[0]);
                }

                double fuelAmount = double.Parse(inputArgs[1]);
                double fuelConsumption = double.Parse(inputArgs[2]);

                Car currentCar = new Car(model, fuelAmount, fuelConsumption);
                carList.Add(currentCar);
            }

            string command = Console.ReadLine().Trim();

            while (command != "End")
            {
                string[] commandArgs = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string carModel = commandArgs[1];
                double km = double.Parse(commandArgs[2]);

                Car current = carList.Where(x => x.Model == carModel).FirstOrDefault();
                current.Drive(km);

                command = Console.ReadLine().Trim();
            }

            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTravel}");
            }
        }
    }
}
