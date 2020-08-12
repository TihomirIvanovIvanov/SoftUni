using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var parkingSpots = new Dictionary<int, List<int>>();

            var sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];

            for (int i = 0; i < rows; i++)
            {
                parkingSpots.Add(i, new List<int>() { 0 });
            }

            string input;

            while ((input = Console.ReadLine()) != "stop")
            {
                var coordinates = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = coordinates[0];
                var targetRow = coordinates[1];
                var targetCol = coordinates[2];

                if (!parkingSpots[targetRow].Contains(targetCol))
                {
                    parkingSpots[targetRow].Add(targetCol);

                    var steps = Math.Abs(entryRow - targetRow) + targetCol + 1;

                    Console.WriteLine(steps);
                }
                else if (parkingSpots[targetRow].Count == cols)
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                else
                {
                    var counter = 1;

                    while (true)
                    {
                        var steps = targetCol - counter;

                        if (!parkingSpots[targetRow].Contains(steps) && steps > 0)
                        {
                            parkingSpots[targetRow].Add(steps);
                            var totalSteps = Math.Abs(entryRow - targetRow) + steps + 1;

                            Console.WriteLine(totalSteps);
                            break;
                        }

                        steps = targetCol + counter;

                        if (!parkingSpots[targetRow].Contains(steps) && steps < cols)
                        {
                            parkingSpots[targetRow].Add(steps);
                            var totalSteps = Math.Abs(entryRow - targetRow) + steps + 1;

                            Console.WriteLine(totalSteps);
                            break;
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
