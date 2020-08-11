﻿using System;

namespace TheHeiganDance
{
    class Program
    {
        static int playerRow = 7;

        static int playerCol = 7;

        static int plagueCloud = 3500;

        static int eruption = 6000;

        static int playerLifePoints = 18500;

        static double heiganLifePoints = 3000000;

        static bool isPlagueCloud = false;

        static string lastSpell = string.Empty;

        static void Main(string[] args)
        {
            var pointsAgainstHeigan = double.Parse(Console.ReadLine());

            while (true)
            {
                if (playerLifePoints > 0)
                {
                    heiganLifePoints -= pointsAgainstHeigan;
                }

                if (isPlagueCloud)
                {
                    playerLifePoints -= plagueCloud;
                    isPlagueCloud = false;
                }

                if (playerLifePoints <= 0 || heiganLifePoints <= 0)
                {
                    break;
                }

                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var magic = input[0];
                var targetRow = int.Parse(input[1]);
                var targetCol = int.Parse(input[2]);

                if (!IsInImpactArea(playerRow, playerCol, targetRow, targetCol))
                {
                    continue;
                }

                var canMoveUp = !IsInImpactArea(playerRow - 1, playerCol, targetRow, targetCol) && IsInside(playerRow - 1);
                var canMoveRight = !IsInImpactArea(playerRow, playerCol + 1, targetRow, targetCol) && IsInside(playerCol + 1);
                var canMoveDown = !IsInImpactArea(playerRow + 1, playerCol, targetRow, targetCol) && IsInside(playerRow + 1);
                var canMoveLeft = !IsInImpactArea(playerRow, playerCol - 1, targetRow, targetCol) && IsInside(playerCol - 1);

                if (canMoveUp)
                {
                    playerRow--;
                    continue;
                }
                if (canMoveRight)
                {
                    playerCol++;
                    continue;
                }
                if (canMoveDown)
                {
                    playerRow++;
                    continue;
                }
                if (canMoveLeft)
                {
                    playerCol--;
                    continue;
                }

                if (magic == "Cloud")
                {
                    playerLifePoints -= plagueCloud;
                    isPlagueCloud = true;
                    lastSpell = "Plague Cloud";
                }
                else if (magic == "Eruption")
                {
                    playerLifePoints -= eruption;
                    lastSpell = "Eruption";
                }
            }

            if (heiganLifePoints <= 0)
            {
                Console.WriteLine($"Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganLifePoints:F2}");
            }

            if (playerLifePoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"“Player: {playerLifePoints}");
            }

            Console.WriteLine($"Final position: {playerRow}, {playerCol}");
        }

        private static bool IsInside(int rowColIndex)
        {
            return rowColIndex >= 0 && rowColIndex < 15;
        }

        private static bool IsInImpactArea(int targetPlayerRow, int targetPlayerCol, int row, int col)
        {
            return targetPlayerRow >= row - 1 && targetPlayerRow <= row + 1 &&
                   targetPlayerCol >= col - 1 && targetPlayerCol <= col + 1;
        }
    }
}
