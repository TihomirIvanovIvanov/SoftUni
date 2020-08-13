using System;
using System.Collections.Generic;

namespace SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            var vips = new SortedSet<string>();
            var guests = new SortedSet<string>();

            var input = Console.ReadLine();

            while (input?.ToLower() != "party")
            {
                if (char.IsDigit(input[0]))
                {
                    vips.Add(input);
                }
                else
                {
                    guests.Add(input);
                }

                input = Console.ReadLine();
            }

            while (input?.ToLower() != "end")
            {
                if (char.IsDigit(input[0]))
                {
                    vips.Remove(input);
                }
                else
                {
                    guests.Remove(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count + vips.Count);

            foreach (var guest in vips)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
