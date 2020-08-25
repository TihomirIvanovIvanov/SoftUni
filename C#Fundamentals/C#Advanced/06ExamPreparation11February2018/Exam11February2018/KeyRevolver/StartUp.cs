using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    public class StartUp
    {
        public static void Main()
        {
            var pricePerBullet = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());

            var bulletsArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var bullets = new Stack<int>(bulletsArr);

            var lockArr = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var locks = new Queue<int>(lockArr);

            var value = int.Parse(Console.ReadLine());
            var counter = 0;

            while (locks.Count > 0 && bullets.Count > 0)
            {
                var bullet = bullets.Pop();

                if (bullet <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                counter++;

                if (counter % barrelSize == 0 && bullets.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                var initialBulletsCount = bulletsArr.Length;
                var spentForBullets = counter * pricePerBullet;
                var result = value - spentForBullets;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${result}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
