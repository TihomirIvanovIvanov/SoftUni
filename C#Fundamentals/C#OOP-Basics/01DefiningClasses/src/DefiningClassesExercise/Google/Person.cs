using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Google
{
    public class Person
    {
        private string name;

        private Company company;

        private Car car;

        private List<Parent> parents;

        private List<Child> children;

        private List<Pokemon> pokemons;

        public Person(string name)
        {
            this.Name = name;
            this.Company = Company;
            this.Car = Car;
            this.Parents = new List<Parent>();
            this.Children = new List<Child>();
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public Company Company { get; set; }

        public Car Car { get; set; }

        public List<Parent> Parents { get; set; }

        public List<Child> Children { get; set; }

        public List<Pokemon> Pokemons { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Name);
            sb.AppendLine("Company: ");

            if (this.Company != null)
            {
                sb.AppendLine(this.Company.ToString());
            }

            sb.AppendLine("Car: ");

            if (this.Car != null)
            {
                sb.AppendLine(this.Car.ToString());
            }

            sb.AppendLine("Pokemon: ");

            if (this.Pokemons.Any())
            {
                this.Pokemons
                    .ForEach(p => sb.AppendLine(p.ToString()));
            }

            sb.AppendLine("Parents: ");

            if (this.Parents.Any())
            {
                this.Parents
                    .ForEach(p => sb.AppendLine(p.ToString()));
            }
            sb.AppendLine("Children: ");

            if (this.Children.Any())
            {
                this.Children
                    .ForEach(ch => sb.AppendLine(ch.ToString()));
            }

            return sb.ToString().Trim();
        }
    }
}
