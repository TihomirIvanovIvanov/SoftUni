using System.Collections.Generic;

namespace FamilyTree
{
    public class Person
    {
        private string name;

        private string bithday;

        private List<Person> children;

        private List<Person> parents;

        public Person(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public List<Person> Children { get; set; }

        public List<Person> Parents { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Birthday}";
        }
    }
}
