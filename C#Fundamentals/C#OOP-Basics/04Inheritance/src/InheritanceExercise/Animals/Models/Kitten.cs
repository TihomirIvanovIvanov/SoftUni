namespace Animals.Models
{
    public class Kitten : Cat
    {
        private const string gender = "Female";

        public Kitten(string name, int age)
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Meow");
        }
    }
}
