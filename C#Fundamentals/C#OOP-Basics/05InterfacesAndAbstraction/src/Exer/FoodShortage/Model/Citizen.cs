using FoodShortage.Contracts;
using System;

namespace FoodShortage.Model
{
    public class Citizen : IAgeble, IIdentifiable, IBirthable, IBuyerble
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Id { get; }

        public DateTime Birthdate { get; }

        public string Name { get; }

        public int Age { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
