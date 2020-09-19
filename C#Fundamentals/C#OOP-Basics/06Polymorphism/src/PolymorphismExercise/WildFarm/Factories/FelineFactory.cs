using System;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class FelineFactory
    {
        public Feline Create(string type, string name, double weight, string livingRegion, string breed)
        {
            type = type.ToLower();

            return type switch
            {
                "cat" => new Cat(name, weight, livingRegion, breed),
                "tiger" => new Tiger(name, weight, livingRegion, breed),
                _ => throw new ArgumentException("Invalid feline type!"),
            };
        }
    }
}
