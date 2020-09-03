namespace Animals.Models
{
    using System;

    public abstract class Animal : ISoundProducable
    {
        private string name;

        private int age;

        private string gender;

        protected Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Invalid input!");
                }
                this.age = value;
            }
        }

        public string Gender
        {
            get => this.gender;
            set
            {
                if (value == null || string.IsNullOrEmpty(value))
                {
                    throw new Exception("Invalid input!");
                }
                this.gender = value;
            }
        }

        public virtual void ProduceSound()
        {
            Console.WriteLine("Screaaam!");
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age} {this.Gender}";
        }
    }
}
