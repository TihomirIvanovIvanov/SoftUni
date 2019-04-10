namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int amountOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < amountOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                var tires = new List<Tire>();

                for (int j = 0; j < 8; j += 2)
                {
                    double currentTirePressure = double.Parse(carInfo[5 + j]);
                    int currentTireAge = int.Parse(carInfo[6 + j]);

                    var tire = new Tire(currentTirePressure, currentTireAge);
                    tires.Add(tire);
                }

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(carModel, engine, cargo, tires);

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