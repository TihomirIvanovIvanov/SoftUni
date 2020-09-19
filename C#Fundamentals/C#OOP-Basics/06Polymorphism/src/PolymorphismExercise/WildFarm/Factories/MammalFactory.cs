using System;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class MammalFactory
    {
        public Mammal Create(string type, string name, double weight, string livingRegion)
        {
            type = type.ToLower();

            return type switch
            {
                "dog" => new Dog(name, weight, livingRegion),
                "mouse" => new Mouse(name, weight, livingRegion),
                _ => throw new ArgumentException("Invalid mammal type!"),
            };
        }
    }
}
