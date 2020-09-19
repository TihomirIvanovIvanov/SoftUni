using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double foodIncrease = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.Weight += food.Quantity * foodIncrease;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Cluck");
        }
    }
}
