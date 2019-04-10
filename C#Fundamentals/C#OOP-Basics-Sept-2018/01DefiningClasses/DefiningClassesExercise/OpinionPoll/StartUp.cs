namespace OpinionPoll
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);

                var person = new Person(personName, personAge);
                people.Add(person);
            }

            people
                .Where(a => a.Age > 30)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}