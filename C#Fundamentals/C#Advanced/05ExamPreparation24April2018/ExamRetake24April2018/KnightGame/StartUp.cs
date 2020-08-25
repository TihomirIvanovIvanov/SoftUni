using System;

namespace KnightGame
{
    public class StartUp
    {
        private static char[][] matrix;

        private static int[][] knightsToRemove;

        public static void Main()
        {
            FillUpMatrix();

            var removed = 0;
            while (true)
            {
                FillUpKnightsMatrix();

                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            MoveLeftDown(row, col);
                            MoveRightDown(row, col);
                            MoveLeftUp(row, col);
                            MoveRightUp(row, col);
                        }
                    }
                }

                if (!RemoveMostAttackedKnight())
                {
                    break;
                }

                removed++;
            }
            Console.WriteLine(removed);
        }

        private static bool RemoveMostAttackedKnight()
        {
            var mostAttacked = 0;
            var removeRow = 0;
            var removeCol = 0;

            for (int row = 0; row < knightsToRemove.Length; row++)
            {
                for (int col = 0; col < knightsToRemove[row].Length; col++)
                {
                    if (knightsToRemove[row][col] > mostAttacked)
                    {
                        removeRow = row;
                        removeCol = col;
                        mostAttacked = knightsToRemove[row][col];
                    }
                }
            }
            if (mostAttacked == 0)
            {
                return false;
            }
            matrix[removeRow][removeCol] = '0';
            return true;
        }

        private static void MoveRightUp(int row, int col)
        {
            var newRow = row - 2;
            var newCol = col + 1;
            ValidateRightUpMove(newRow, newCol);

            newRow = row - 1;
            newCol = col + 2;
            ValidateRightUpMove(newRow, newCol);
        }

        private static void ValidateRightUpMove(int row, int col)
        {
            if (col < matrix.Length && row >= 0)
            {
                IsKnight(row, col);
            }
        }

        private static void MoveLeftUp(int row, int col)
        {
            var newRow = row - 2;
            var newCol = col - 1;
            ValidateLeftUpMove(newRow, newCol);

            newRow = row - 1;
            newCol = col - 2;
            ValidateLeftUpMove(newRow, newCol);
        }

        private static void ValidateLeftUpMove(int row, int col)
        {
            if (col >= 0 && row >= 0)
            {
                IsKnight(row, col);
            }
        }

        private static void MoveRightDown(int row, int col)
        {
            var newRow = row + 2;
            var newCol = col + 1;
            ValidateRightDownMove(newRow, newCol);

            newRow = row + 1;
            newCol = col + 2;
            ValidateRightDownMove(newRow, newCol);
        }

        private static void ValidateRightDownMove(int row, int col)
        {
            if (col < matrix.Length && row < matrix.Length)
            {
                IsKnight(row, col);
            }
        }

        private static void MoveLeftDown(int row, int col)
        {
            var newRow = row + 2;
            var newCol = col - 1;
            ValidateLeftDownMove(newRow, newCol);

            newRow = row + 1;
            newCol = col - 2;
            ValidateLeftDownMove(newRow, newCol);
        }

        private static void ValidateLeftDownMove(int row, int col)
        {
            if (col >= 0 && row < matrix.Length)
            {
                IsKnight(row, col);
            }
        }

        private static void IsKnight(int row, int col)
        {
            if (matrix[row][col] == 'K')
            {
                knightsToRemove[row][col]++;
            }
        }

        private static void FillUpKnightsMatrix()
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                knightsToRemove[i] = new int[matrix.Length];
            }
        }

        private static void FillUpMatrix()
        {
            var n = int.Parse(Console.ReadLine());
            matrix = new char[n][];
            knightsToRemove = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Trim()
                    .ToCharArray();
            }
        }
    }
}
