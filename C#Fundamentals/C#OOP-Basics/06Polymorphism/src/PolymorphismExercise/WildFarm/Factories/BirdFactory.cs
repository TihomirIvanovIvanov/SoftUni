using System;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class BirdFactory
    {
        public Bird Create(string type, string name, double weight, double wingSize)
        {
            type = type.ToLower();

            return type switch
            {
                "hen" => new Hen(name, weight, wingSize),
                "owl" => new Owl(name, weight, wingSize),
                _ => throw new ArgumentException("Invalid bird type!"),
            };
        }
    }
}
