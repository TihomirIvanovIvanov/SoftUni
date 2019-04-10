namespace OldestFamilyMember
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var numberOfPeople = int.Parse(Console.ReadLine());
            var people = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);

                var person = new Person(name, age);
                people.AddMember(person);
            }

            var oldestPerson = people.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");

            //var numberOfPeople = int.Parse(Console.ReadLine());
            //var people = new Family();

            //for (int i = 0; i < numberOfPeople; i++)
            //{
            //    var personInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //    var personName = personInfo[0];
            //    var personAge = int.Parse(personInfo[1]);

            //    var person = new Person(personName, personAge);
            //    people.AddMember(person);
            //}

            //Console.WriteLine(people.GetOldestMember().ToString());
        }
    }
}