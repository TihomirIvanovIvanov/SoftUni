namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var people = new List<Person>();
            Person person = null;

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var personName = tokens[0];
                var cmd = tokens[1];
                var isConstains = false;

                foreach (var human in people)
                {
                    if (human.Name == personName)
                    {
                        isConstains = true;
                        break;
                    }
                }

                if (isConstains)
                {
                    person = people.First(p => p.Name == personName);
                }
                else
                {
                    person = new Person(personName);
                }

                if (cmd == "company")
                {
                    var companyName = tokens[2];
                    var companyDepart = tokens[3];
                    var companySalary = decimal.Parse(tokens[4]);
                    person.Company = new Company(companyName, companyDepart, companySalary);
                }
                else if (cmd == "pokemon")
                {
                    var pokemonName = tokens[2];
                    var pokemonType = tokens[3];
                    person
                        .Pokemons
                        .Add(new Pokemon(pokemonName, pokemonType));
                }
                else if (cmd == "parents")
                {
                    var parentName = tokens[2];
                    var parentBirthday = tokens[3];
                    person
                        .Parents
                        .Add(new Parent(parentName, parentBirthday));
                }
                else if (cmd == "children")
                {
                    var childName = tokens[2];
                    var childBirthday = tokens[3];
                    person
                        .Children
                        .Add(new Child(childName, childBirthday));
                }
                else if (cmd == "car")
                {
                    var carModel = tokens[2];
                    var carSpeed = int.Parse(tokens[3]);
                    person.Car = new Car(carModel, carSpeed);
                }
                people.Add(person);
            }

            var inputPersonName = Console.ReadLine();
            var personForPrint = people.First(p => p.Name == inputPersonName);

            Console.WriteLine(personForPrint);
        }
    }
}