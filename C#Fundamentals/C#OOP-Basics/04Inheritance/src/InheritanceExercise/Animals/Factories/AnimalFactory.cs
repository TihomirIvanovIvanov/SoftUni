namespace Animals.Factories
{
    using Models;
    using System;

    public class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, int age, string gender)
        {
            type = type.ToLower();

            return type switch
            {
                "cat" => new Cat(name, age, gender),
                "dog" => new Dog(name, age, gender),
                "frog" => new Frog(name, age, gender),
                "kitten" => new Kitten(name, age),
                "tomcat" => new Tomcat(name, age),
                _ => throw new Exception("Invalid input!"),
            };
        }
    }
}