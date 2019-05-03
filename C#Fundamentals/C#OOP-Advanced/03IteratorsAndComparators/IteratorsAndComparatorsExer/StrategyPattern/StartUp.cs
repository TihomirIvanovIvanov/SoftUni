namespace StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> nameComparators = new SortedSet<Person>(new NameComparator());
            SortedSet<Person> ageComparators = new SortedSet<Person>(new AgeComparator());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var peopleInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = peopleInfo[0];
                var age = int.Parse(peopleInfo[1]);

                var person = new Person(name, age);
                nameComparators.Add(person);
                ageComparators.Add(person);
            }

            foreach (var person in nameComparators)
            {
                Console.WriteLine(person);
            }

            foreach (var person in ageComparators)
            {
                Console.WriteLine(person);
            }
        }
    }
}