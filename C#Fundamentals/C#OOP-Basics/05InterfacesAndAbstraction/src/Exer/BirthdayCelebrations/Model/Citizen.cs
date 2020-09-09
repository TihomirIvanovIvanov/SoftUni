using BirthdayCelebrations.Contracts;
using System;

namespace BirthdayCelebrations.Model
{
    public class Citizen : IIdentifiable, IBirthable, INameble
    {
        private readonly int age;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = Name;
            this.age = age;
            this.Id = id;
            this.Birthdate = DateTime.ParseExact(birthdate, "dd/mm/yyyy", null);
        }

        public string Id { get; }

        public DateTime Birthdate { get; }

        public string Name { get; }
    }
}
