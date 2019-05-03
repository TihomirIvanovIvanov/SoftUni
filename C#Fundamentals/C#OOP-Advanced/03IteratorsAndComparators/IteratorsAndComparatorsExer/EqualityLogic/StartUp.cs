namespace EqualityLogic
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> sortedPerson = new SortedSet<Person>();
            HashSet<Person> hashPerson = new HashSet<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                var person = new Person(name, age);
                sortedPerson.Add(person);
                hashPerson.Add(person);
            }

            Console.WriteLine(sortedPerson.Count);
            Console.WriteLine(hashPerson.Count);
        }
    }
}