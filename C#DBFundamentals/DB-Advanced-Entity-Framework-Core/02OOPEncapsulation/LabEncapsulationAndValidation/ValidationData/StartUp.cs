namespace ValidationData
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> persons = new List<Person>();
            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] linesArgs = Console.ReadLine().Split();

                    string firstName = linesArgs[0];
                    string lastName = linesArgs[1];
                    int age = int.Parse(linesArgs[2]);
                    double salary = double.Parse(linesArgs[3]);

                    Person person = new Person(firstName, lastName, age, salary);
                    persons.Add(person);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
