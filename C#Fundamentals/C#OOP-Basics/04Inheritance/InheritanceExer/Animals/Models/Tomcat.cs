namespace Animals.Models
{
    public class Tomcat : Cat
    {
        private const string gender = "Male";

        public Tomcat(string name, int age) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("MEOW");
        }
    }
}