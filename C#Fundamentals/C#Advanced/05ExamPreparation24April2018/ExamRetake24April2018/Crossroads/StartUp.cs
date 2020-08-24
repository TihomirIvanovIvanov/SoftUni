using System;
using System.Collections.Generic;

namespace Crossroads
{
    public class StartUp
    {
        public static void Main()
        {
            var greenTime = int.Parse(Console.ReadLine());
            var freeWindow = int.Parse(Console.ReadLine());

            var cars = new Queue<string>();
            var totalCars = 0;

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "green")
                {
                    GreenLightOn(cars, greenTime, freeWindow);
                }
                else
                {
                    cars.Enqueue(command);
                    totalCars++;
                }
            }

            Console.WriteLine($"Everyone is safe.{Environment.NewLine}" +
                $"{totalCars - cars.Count} total cars passed the crossroads.");
        }

        private static void GreenLightOn(Queue<string> cars, int greenTime, int freeWindow)
        {
            var car = string.Empty;

            while (cars.Count > 0 && greenTime > 0)
            {
                car = cars.Dequeue();
                if (car.Length <= greenTime)
                {
                    greenTime -= car.Length;
                }
                else
                {
                    var partsInside = car.Substring(greenTime);
                    IsCrash(partsInside, freeWindow, car);
                    break;
                }
            }
        }

        private static void IsCrash(string partsInside, int freeWindow, string car)
        {
            if (partsInside.Length > freeWindow)
            {
                Console.WriteLine($"A crash happened!{Environment.NewLine}{car} was hit at {partsInside[freeWindow]}.");
                Environment.Exit(0);
            }
        }
    }
}
