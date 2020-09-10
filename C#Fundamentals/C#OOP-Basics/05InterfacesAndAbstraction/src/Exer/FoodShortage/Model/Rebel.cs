using FoodShortage.Contracts;

namespace FoodShortage.Model
{
    public class Rebel : IBuyerble, IAgeble
    {
        private readonly string group;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.group = group;
        }   

        public int Age { get; }

        public string Name { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
