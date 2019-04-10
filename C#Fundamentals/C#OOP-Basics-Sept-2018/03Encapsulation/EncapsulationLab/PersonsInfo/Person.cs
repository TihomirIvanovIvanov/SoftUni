namespace PersonsInfo
{
    using System;

    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}