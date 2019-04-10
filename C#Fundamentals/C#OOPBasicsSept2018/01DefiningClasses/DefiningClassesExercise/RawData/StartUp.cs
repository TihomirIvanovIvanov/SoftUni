namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var amountOfCars = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < amountOfCars; i++)
            {
                var inputArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = inputArgs[0];
                var engineSpeed = int.Parse(inputArgs[1]);
                var enginePower = int.Parse(inputArgs[2]);
                var cargoWeight = int.Parse(inputArgs[3]);
                var cargoType = inputArgs[4];

                var tyres = new List<Tyre>();

                for (int j = 0; j < 4; j += 2)
                {
                    var tyrePressure = double.Parse(inputArgs[5 + j]);
                    var tyreAge = int.Parse(inputArgs[6 + j]);

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
                    .Where(c => c.Cargo.Type == command && c.Tyres.Any(p => p.Pressure < 1))
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

            //var amountOfCars = int.Parse(Console.ReadLine());
            //var cars = new List<Car>();

            //for (int i = 0; i < amountOfCars; i++)
            //{
            //    var carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    var model = carInfo[0];
            //    var engineSpeed = int.Parse(carInfo[1]);
            //    var enginePower = int.Parse(carInfo[2]);
            //    var cargoWeight = int.Parse(carInfo[3]);
            //    var cargoType = carInfo[4];

            //    var tyre1Pressure = double.Parse(carInfo[5]);
            //    var tyre1Age = int.Parse(carInfo[6]);

            //    var tyre2Pressure = double.Parse(carInfo[7]);
            //    var tyre2Age = int.Parse(carInfo[8]);

            //    var tyre3Pressure = double.Parse(carInfo[9]);
            //    var tyre3Age = int.Parse(carInfo[10]);

            //    var tyre4Pressure = double.Parse(carInfo[11]);
            //    var tyre4Age = int.Parse(carInfo[12]);

            //    var currentCar = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
            //                             tyre1Pressure, tyre1Age,
            //                             tyre2Pressure, tyre2Age,
            //                             tyre3Pressure, tyre3Age,
            //                             tyre4Pressure, tyre4Age);

            //    cars.Add(currentCar);
            //}

            //var command = Console.ReadLine();

            //if (command == "fragile")
            //{
            //    var filtratedCars = cars
            //        .Where(c => c.Cargo.CargoType == command)
            //        .Where(c => c.Tyres.Any(t => t.Pressure < 1));

            //    foreach (var car in filtratedCars)
            //    {
            //        Console.WriteLine(car.Model);
            //    }
            //}
            //else if (command == "flamable")
            //{
            //    var filtratedCars = cars
            //        .Where(c => c.Cargo.CargoType == command)
            //        .Where(e => e.Engine.EnginePower > 250);

            //    foreach (var car in filtratedCars)
            //    {
            //        Console.WriteLine(car.Model);
            //    }
            //}
        }
    }
}