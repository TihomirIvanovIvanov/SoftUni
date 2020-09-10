using FoodShortage.Contracts;
using FoodShortage.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main()
        {
            var buyers = new List<IBuyerble>();

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (personInfo.Length == 4)
                {
                    var citizenName = personInfo[0];
                    var citizenAge = int.Parse(personInfo[1]);
                    var citizenId = personInfo[2];
                    var citizenBirthdate = personInfo[3];

                    var citizen = new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate);
                    buyers.Add(citizen);
                }
                else if (personInfo.Length == 3)
                {
                    var rebelName = personInfo[0];
                    var rebelAge = int.Parse(personInfo[1]);
                    var rebelGroup = personInfo[2];

                    var rebel = new Rebel(rebelName, rebelAge, rebelGroup);
                    buyers.Add(rebel);
                }
            }

            string personName;
            while ((personName = Console.ReadLine()) != "End")
            {
                var buyer = buyers
                    .FirstOrDefault(buyer => buyer.Name == personName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(buyers => buyers.Food));
        }
    }
}
