using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var engineModel = engineInfo[0];
                var enginePower = engineInfo[1];
                string engineDisplacement = null;
                string engineEfficiency = null;

                if (engineInfo.Length == 3)
                {
                    var isNumber = int.TryParse(engineInfo[2], out int parsedDisplacement);

                    if (isNumber)
                    {
                        engineDisplacement = parsedDisplacement.ToString();
                    }
                    else
                    {
                        engineEfficiency = engineInfo[2];
                    }
                }

                if (engineInfo.Length == 4)
                {
                    engineDisplacement = engineInfo[2];
                    engineEfficiency = engineInfo[3];
                }

                var currentEngine = new Engine();
                currentEngine.Model = engineModel;
                currentEngine.Power = enginePower;
                currentEngine.Displacement = engineDisplacement;
                currentEngine.Efficiency = engineEfficiency;

                engines.Add(currentEngine);
            }

            var cars = new List<Car>();

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var carModel = carInfo[0];
                var carEngine = carInfo[1];
                string carWeight = null;
                string carColor = null;

                if (carInfo.Length == 3)
                {
                    var isNumber = int.TryParse(carInfo[2], out int parsedWeight);

                    if (isNumber)
                    {
                        carWeight = parsedWeight.ToString();
                    }
                    else
                    {
                        carColor = carInfo[2];
                    }
                }

                if (carInfo.Length == 4)
                {
                    carWeight = carInfo[2];
                    carColor = carInfo[3];
                }

                var currentCar = new Car();
                currentCar.Model = carModel;
                currentCar.Engine = engines.FirstOrDefault(e => e.Model == carEngine);
                currentCar.Weight = carWeight;
                currentCar.Color = carColor;

                cars.Add(currentCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
