using System;
using System.Linq;

namespace ParkingFeud
{
    public class StartUp
    {
        public static void Main()
        {
            var parking = CreateParking();

            var entranceNumber = int.Parse(Console.ReadLine());

            TryPark(entranceNumber, parking);
        }

        private static void TryPark(int entranceNumber, bool[][] parking)
        {
            var parked = false;
            var totalDistance = 0;
            var maxColumnIndex = parking[0].Length - 1;
            string parkingSpot = null;

            while (!parked)
            {
                var positionsInput = Console.ReadLine();
                var positions = positionsInput.Split();

                var index = entranceNumber - 1;
                parkingSpot = positions[index];

                var conflictIndex = -1;

                for (int i = 0; i < positions.Length; i++)
                {
                    if (parkingSpot == positions[i] && i != index)
                    {
                        conflictIndex = i;
                    }
                }

                var currentDistance = CalculateDistance(entranceNumber, parkingSpot, maxColumnIndex);
                totalDistance += currentDistance;

                if (conflictIndex >= 0)
                {
                    var otherCarDistance = CalculateDistance(conflictIndex + 1, positions[conflictIndex], maxColumnIndex);
                    if (currentDistance > otherCarDistance)
                    {
                        totalDistance += currentDistance;
                    }
                    else
                    {
                        parked = true;
                    }
                }
                else
                {
                    parked = true;
                }
            }

            ParkSuccess(parkingSpot, totalDistance);
        }

        private static void ParkSuccess(string parkingSpot, int totalDistance)
        {
            Console.WriteLine($"Parked successfully at {parkingSpot}.");
            Console.WriteLine($"Total Distance Passed: {totalDistance}");
        }

        //Calculates the distance from an entrance to the parking spot
        private static int CalculateDistance(int entranceNumber, string targetParkingSpot, int finalColumnIndex)
        {
            var goingLeft = true;
            var currentPosition = new int[] { entranceNumber * 2 - 1, 0 };
            var parkingSpotPosition = GetParkingSpotPosition(targetParkingSpot);
            var distance = 0;

            while (!AtSpot(currentPosition, parkingSpotPosition))
            {
                distance++;

                //Move the car
                currentPosition[1] += goingLeft ? 1 : -1;

                var reachedTheEnd = currentPosition[1] == finalColumnIndex && goingLeft ||
                    currentPosition[1] == 0 && !goingLeft;

                //If you reach the end of the row, go up/down and change direction
                if (reachedTheEnd)
                {
                    var targetRowIsAbove = currentPosition[0] > parkingSpotPosition[0];
                    currentPosition[0] += targetRowIsAbove ? -2 : 2;
                    goingLeft = !goingLeft;
                    distance += 2;
                }
            }

            return distance;
        }

        //Checks if the car is next to the desired spot
        private static bool AtSpot(int[] currentPosition, int[] parkingSpotPosition)
        {
            var sameCol = currentPosition[1] == parkingSpotPosition[1];

            var rowAboveSpot = currentPosition[0] == parkingSpotPosition[0] - 1;
            var rowBelowSpot = currentPosition[0] == parkingSpotPosition[0] + 1;
            var rowNextToSpot = rowAboveSpot || rowBelowSpot;

            return sameCol && rowNextToSpot;
        }

        //Gets the coordinates of a spot
        private static int[] GetParkingSpotPosition(string parkingSpot)
        {
            var letter = parkingSpot[0];
            var row = (int.Parse(parkingSpot.Substring(1)) - 1) * 2;
            var column = letter - 'A' + 1;

            return new int[] { row, column };
        }

        //Initiates the parking lot, not really necessary
        private static bool[][] CreateParking()
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var actualRows = dimensions[0] * 2 - 1;
            var actualCols = dimensions[1] + 2;

            var parking = new bool[actualRows][];

            for (int rowNumber = 0; rowNumber < actualRows; rowNumber++)
            {
                parking[rowNumber] = new bool[actualCols];
            }

            return parking;
        }
    }
}
