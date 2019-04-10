namespace OldestFamilyMember
{
    using System.Collections.Generic;
    using System.Linq;

    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.People = new List<Person>();
        }

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.People
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }

        //private List<Person> people;

        //public Family()
        //{
        //    this.people = new List<Person>();
        //}

        //public void AddMember(Person member)
        //{
        //    this.people.Add(member);
        //}

        //public Person GetOldestMember()
        //{
        //    return this.people
        //        .OrderByDescending(p => p.Age)
        //        .FirstOrDefault();
        //}
    }
}