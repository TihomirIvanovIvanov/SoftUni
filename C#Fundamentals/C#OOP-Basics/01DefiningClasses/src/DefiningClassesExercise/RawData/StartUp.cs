using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);


                var model = inputArgs[0];
                var engineSpeed = int.Parse(inputArgs[1]);
                var enginePower = int.Parse(inputArgs[2]);
                var cargoWeight = int.Parse(inputArgs[3]);
                var cargoType = inputArgs[4];

                var tyres = new List<Tyre>();

                for (int t = 0; t < 4; t += 2)
                {
                    var tyrePressure = double.Parse(inputArgs[5 + t]);
                    var tyreAge = int.Parse(inputArgs[6 + t]);

                    var tyre = new Tyre(tyrePressure, tyreAge);
                    tyres.Add(tyre);
                }

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, cargo, tyres);

                cars.Add(car);
            }

            var command = Console.ReadLine();

            var resultCars = new List<Car>();

            if (command == "fragile")
            {
                resultCars = cars
                    .Where(c => c.Cargo.Type == command && c.Tyres.Any(t => t.Pressure < 1))
                    .ToList();
            }
            else
            {
                resultCars = cars
                    .Where(c => c.Cargo.Type == command && c.Engine.Power > 250)
                    .ToList();
            }

            foreach (var car in resultCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}
