namespace P02_CarsSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int numberOfEngines = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string engineModel = engineInfo[0];
                double enginePower = double.Parse(engineInfo[1]);

                var engine = new Engine(engineModel, enginePower);

                if (engineInfo.Length > 2)
                {
                    var displacementOrEfficiency = engineInfo[2];
                    double result;
                    var isNumber = double.TryParse(displacementOrEfficiency, out result);

                    if (isNumber)
                    {
                        engine.Displacement = displacementOrEfficiency;
                    }
                    else
                    {
                        engine.Efficiency = displacementOrEfficiency;
                    }
                }

                if (engineInfo.Length > 3)
                {
                    engine.Efficiency = engineInfo[3];
                }

                engines.Add(engine);
            }

            int numbersOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersOfCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string carModel = carInfo[0];
                string carEngine = carInfo[1];

                var car = new Car(carModel, engines.FirstOrDefault(e => e.Model == carEngine));

                if (carInfo.Length > 2)
                {
                    var colorOrWeight = carInfo[2];
                    double result;
                    var isNumber = double.TryParse(colorOrWeight, out result);

                    if (isNumber)
                    {
                        car.Weight = colorOrWeight;
                    }
                    else
                    {
                        car.Color = colorOrWeight;
                    }
                }

                if (carInfo.Length > 3)
                {
                    car.Color = carInfo[3];
                }

                cars.Add(car);
            }

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }
    }
}