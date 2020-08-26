using System;
using System.Collections;
using System.Linq;

namespace CupsAndBottles
{
    public class StartUp
    {
        public static void Main()
        {
            var cups = new Queue(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var bottles = new Stack(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var wastedLiters = 0;
            var cup = 1;
            var bottle = 1;
            var first = true;

            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (cup <= 0 || first)
                {
                    cup = int.Parse(cups.Peek().ToString());
                }

                bottle = int.Parse(bottles.Peek().ToString());
                cup -= bottle;

                if (cup <= 0)
                {
                    wastedLiters += Math.Abs(cup);
                    cups.Dequeue();
                    bottles.Pop();
                }
                else
                {
                    bottles.Pop();

                    while (cup > 0)
                    {
                        bottle = int.Parse(bottles.Pop().ToString());
                        cup -= bottle;

                        if (cup <= 0)
                        {
                            wastedLiters += Math.Abs(cup);
                            cups.Dequeue();
                            break;
                        }
                    }
                }

                first = false;
            }

            if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups.ToArray())}");
            }
            else if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles.ToArray())}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedLiters}");
        }
    }
}
