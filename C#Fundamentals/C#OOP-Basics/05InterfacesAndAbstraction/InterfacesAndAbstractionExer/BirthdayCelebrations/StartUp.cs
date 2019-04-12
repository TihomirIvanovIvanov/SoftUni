namespace BirthdayCelebrations
{
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var all = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();

                switch (inputArgs[0])
                {
                    case "Citizen":
                        var citizenName = inputArgs[1];
                        var citizenAge = int.Parse(inputArgs[2]);
                        var citizenId = inputArgs[3];
                        var citizenBirthdate = inputArgs[4];

                        var citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                        all.Add(citizen);
                        break;

                    case "Pet":
                        var petName = inputArgs[1];
                        var petBirthdate = inputArgs[2];

                        var pet = new Pet(petName, petBirthdate);
                        all.Add(pet);
                        break;
                }
            }

            var year = int.Parse(Console.ReadLine());

            all.Where(c => c.Birthdate.Year == year)
                .Select(c => c.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));
        }
    }
}