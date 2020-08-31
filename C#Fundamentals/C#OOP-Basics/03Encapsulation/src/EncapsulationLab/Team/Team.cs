using System.Collections.Generic;

namespace Team
{
    public class Team
    {
        private string name;

        private readonly List<Person> firstTeam;

        private readonly List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get => name; set => name = value; }

        public IReadOnlyList<Person> FirstTeam => this.firstTeam.AsReadOnly();

        public IReadOnlyList<Person> ReserveTeam => this.reserveTeam.AsReadOnly();

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                this.firstTeam.Add(person);
            }
            else
            {
                this.reserveTeam.Add(person);
            }
        }
    }
}
