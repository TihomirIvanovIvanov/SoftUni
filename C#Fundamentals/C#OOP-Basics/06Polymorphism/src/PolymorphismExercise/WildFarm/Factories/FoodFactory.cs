using System;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food Create(string type, int quantity)
        {
            type = type.ToLower();

            return type switch
            {
                "fruit" => new Fruit(quantity),
                "meat" => new Meat(quantity),
                "seeds" => new Seeds(quantity),
                "vegetable" => new Vegetable(quantity),
                _ => throw new ArgumentException("Invalid food type!"),
            };
        }
    }
}
