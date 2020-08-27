using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var fuelAmount = double.Parse(carInfo[1]);
                var fuelConsumption = double.Parse(carInfo[2]);

                var car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            string comand;
            while ((comand = Console.ReadLine()) != "End")
            {
                var cmdArgs = comand
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = cmdArgs[1];
                var distance = int.Parse(cmdArgs[2]);

                var car = cars.FirstOrDefault(c => c.Model == model);

                if (!car.IsFuelEnough(distance))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelDistance}");
            }
        }
    }
}
