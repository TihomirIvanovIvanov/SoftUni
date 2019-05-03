namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var personInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var town = personInfo[2];

                people.Add(new Person(name, age, town));
            }

            var index = int.Parse(Console.ReadLine()) - 1;
            var person = people[index];

            var equalCounter = 0;
            var nonEqualCounter = 0;

            foreach (var p in people)
            {
                if (p.CompareTo(person) == 0)
                {
                    equalCounter++;
                }
                else
                {
                    nonEqualCounter++;
                }
            }

            if (equalCounter > 1)
            {
                Console.WriteLine($"{equalCounter} {nonEqualCounter} {equalCounter + nonEqualCounter}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}