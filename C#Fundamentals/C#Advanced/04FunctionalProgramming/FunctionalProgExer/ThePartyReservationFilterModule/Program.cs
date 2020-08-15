using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var startsWithCollection = new HashSet<string>();
            var endsWithCollection = new HashSet<string>();
            var lengthCollection = new HashSet<int>();
            var containsCollection = new HashSet<string>();

            string line;
            while ((line = Console.ReadLine()) != "Print")
            {
                var tokens = line.Split(';', StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var filter = tokens[1];
                var parameter = tokens[2];

                if (command == "Add filter")
                {
                    switch (filter)
                    {
                        case "Starts with": startsWithCollection.Add(parameter); break;
                        case "Ends with": endsWithCollection.Add(parameter); break;
                        case "Length": lengthCollection.Add(int.Parse(parameter)); break;
                        case "Contains": containsCollection.Add(parameter); break;
                    }
                }
                else if (command == "Remove filter")
                {
                    switch (filter)
                    {
                        case "Starts with": startsWithCollection.Remove(parameter); break;
                        case "Ends with": endsWithCollection.Remove(parameter); break;
                        case "Length": lengthCollection.Remove(int.Parse(parameter)); break;
                        case "Contains": containsCollection.Remove(parameter); break;
                    }
                }
            }

            startsWithCollection.ToList()
                .ForEach(x =>
                {
                    Predicate<string> startsWith = str => str.StartsWith(x);
                    names = names.Where(name => !startsWith(name)).ToList();
                });
            endsWithCollection.ToList()
                .ForEach(x =>
                {
                    Predicate<string> endsWith = str => str.EndsWith(x);
                    names = names.Where(name => !endsWith(name)).ToList();
                });
            lengthCollection.ToList()
               .ForEach(x =>
               {
                   bool lengthIs(string str) => str.Length == x;
                   names = names.Where(name => !lengthIs(name)).ToList();
               });
            containsCollection.ToList()
               .ForEach(x =>
               {
                   Predicate<string> contais = str => str.Contains(x);
                   names = names.Where(name => !contais(name)).ToList();
               });
            Console.WriteLine(string.Join(' ', names));
        }
    }
}
