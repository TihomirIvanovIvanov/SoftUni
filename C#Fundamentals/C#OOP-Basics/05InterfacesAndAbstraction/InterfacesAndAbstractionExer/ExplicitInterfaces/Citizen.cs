namespace ExplicitInterfaces
{
    using Contracts;

    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Country { get; private set; }

        public string PrintName()
        {
            return this.Name;
        }

        string IResident.PrintName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}