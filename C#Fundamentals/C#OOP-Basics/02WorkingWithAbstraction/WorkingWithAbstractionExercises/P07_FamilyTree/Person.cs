namespace P07_FamilyTree
{
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private List<Person> children;

        public Person()
        {
            this.children = new List<Person>();
        }

        public Person(string name, string birthday)
            : this()
        {
            this.Name = name;
            this.Birthday = birthday;
        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public IReadOnlyList<Person> Children => this.children.AsReadOnly();

        public void AddChild(Person child)
        {
            this.children.Add(child);
        }

        public void AddChildrenInfo(string name, string birthday)
        {
            if (this.children.FirstOrDefault(c => c.Name == name) != null)
            {
                this.children
                    .FirstOrDefault(c => c.Name == name)
                    .Birthday = birthday;
                return;
            }

            if (this.children.FirstOrDefault(c => c.Birthday == birthday) != null)
            {
                this.children
                    .FirstOrDefault(c => c.Birthday == birthday)
                    .Name = name;
            }
        }

        public Person FindChild(string childName)
        {
            return this.children.FirstOrDefault(c => c.Name == childName);
        }
    }
}