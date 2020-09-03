using System;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }

        public override string Name
        {
            get => base.Name;
            set
            {
                base.Name = value;
            }
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15!");
                }
                base.Age = value;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
