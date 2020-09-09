using BirthdayCelebrations.Contracts;
using BirthdayCelebrations.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            var all = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs[0] == "Citizen")
                {
                    var citizenName = inputArgs[1];
                    var citizenAge = int.Parse(inputArgs[2]);
                    var citizenId = inputArgs[3];
                    var citizenBirthdate = inputArgs[4];

                    var citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                    all.Add(citizen);
                }
                else if (inputArgs[0] == "Pet")
                {
                    var petName = inputArgs[1];
                    var petBirthdate = inputArgs[2];

                    var pet = new Pet(petName, petBirthdate);
                    all.Add(pet);
                }
            }

            var year = int.Parse(Console.ReadLine());

            all
                .Where(citizen => citizen.Birthdate.Year == year)
                .Select(citizen => citizen.Birthdate)
                .ToList()
                .ForEach(dateTime => Console.WriteLine($"{dateTime:dd/mm/yyyy}"));
        }
    }
}
