using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
    public class StartUp
    {
        public static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                var tires = new List<Tire>();

                for (int j = 0; j < 8; j += 2)
                {
                    var currentTirePressure = double.Parse(parameters[5 + j]);
                    var currentTireAge = int.Parse(parameters[6 + j]);

                    var tire = new Tire(currentTirePressure, currentTireAge);
                    tires.Add(tire);
                }

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();

            var resultCars = new List<string>();

            if (command == "fragile")
            {
                resultCars = cars
                    .Where(x => x.Cargo.Type == command && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();
            }
            else
            {
                resultCars = cars
                    .Where(x => x.Cargo.Type == command && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, resultCars));
        }
    }
}
