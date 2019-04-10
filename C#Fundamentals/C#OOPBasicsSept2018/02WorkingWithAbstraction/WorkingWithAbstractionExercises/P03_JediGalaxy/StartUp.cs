namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] dimestions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimestions[0];
            int cols = dimestions[1];

            var board = new Board(rows, cols);
            board.InitializeMatrix();

            string command;
            long sum = 0;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] playerCoordinates = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilCoordinates = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var evil = new Player
                {
                    Row = evilCoordinates[0],
                    Col = evilCoordinates[1]
                };

                while (evil.Row >= 0 && evil.Col >= 0)
                {
                    if (board.IsInside(evil.Row, evil.Col))
                    {
                        board.Matrix[evil.Row, evil.Col] = 0;
                    }
                    evil.Row--;
                    evil.Col--;
                }

                var player = new Player
                {
                    Row = playerCoordinates[0],
                    Col = playerCoordinates[1]
                };

                while (player.Row >= 0 && player.Col < board.Matrix.GetLength(1))
                {
                    if (board.IsInside(player.Row, player.Col))
                    {
                        sum += board.Matrix[player.Row, player.Col];
                    }

                    player.Row--;
                    player.Col++;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
