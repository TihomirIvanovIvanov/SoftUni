using System;
using System.Collections.Generic;
using System.Linq;

namespace HitList
{
    public class StartUp
    {
        public static void Main()
        {
            var people = new Dictionary<string, Dictionary<string, string>>();

            var targetIndex = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "end transmissions")
            {
                var commandArgs = command.Split('=', StringSplitOptions.RemoveEmptyEntries);

                var name = commandArgs[0];

                if (!people.ContainsKey(name))
                {
                    people[name] = new Dictionary<string, string>();
                }

                commandArgs = commandArgs[1].Split(';', StringSplitOptions.RemoveEmptyEntries);

                foreach (var pair in commandArgs)
                {
                    var tokens = pair.Split(':', StringSplitOptions.RemoveEmptyEntries);
                    people[name][tokens[0]] = tokens[1];
                }
            }

            var targetMan = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Last();

            Console.WriteLine($"Info on {targetMan}:");
            var man = people[targetMan];

            foreach (var key in man.Keys.OrderBy(k => k))
            {
                Console.WriteLine($"---{key}: {man[key]}");
            }

            var infoIndex = people[targetMan]
                .Select(kvp => kvp.Key.Length + kvp.Value.Length)
                .Sum();

            Console.WriteLine($"Info index: {infoIndex}");

            if (infoIndex >= targetIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetIndex - infoIndex} more info.");
            }
        }
    }
}
