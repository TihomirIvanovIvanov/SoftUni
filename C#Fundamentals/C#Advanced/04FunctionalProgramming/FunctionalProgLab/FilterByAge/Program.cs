using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var people = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people.Add(tokens[0], int.Parse(tokens[1]));
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var tester = CreateTester(condition, age);
            var printer = CreatePrinter(format);
            PrintPeople(people, tester, printer);
        }

        private static void PrintPeople(
            Dictionary<string, int> people, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            var filteredPeople = people
                .Where(x => tester(x.Value));

            foreach (var pair in filteredPeople)
            {
                printer(pair);
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            return format switch
            {
                "name" => pair => Console.WriteLine($"{pair.Key}"),
                "age" => pair => Console.WriteLine($"{pair.Value}"),
                "name age" => pair => Console.WriteLine($"{pair.Key} - {pair.Value}"),
                _ => null,
            };
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            return condition switch
            {
                "younger" => x => x <= age,
                "older" => x => x >= age,
                _ => null,
            };
        }
    }
}
