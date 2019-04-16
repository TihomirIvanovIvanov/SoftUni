namespace SalaryIncrease
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();

                string firstName = cmdArgs[0];
                string lastName = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);
                double salary = double.Parse(cmdArgs[3]);

                var person = new Person(firstName, lastName, age, salary);

                persons.Add(person);
            }
            var bonus = double.Parse(Console.ReadLine());

            foreach (var person in persons)
            {
                person.IncreaseSalary(bonus);
            }

            persons.ForEach(p => Console.WriteLine(p.ToString()));

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}