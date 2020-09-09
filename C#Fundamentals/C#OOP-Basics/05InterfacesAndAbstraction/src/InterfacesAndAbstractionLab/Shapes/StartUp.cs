using System;

namespace Cars
{
    public class StartUp
    {
        //public static void Main()
        //{
        //    var radius = int.Parse(Console.ReadLine());
        //    IDrawable circle = new Circle(radius);

        //    var width = int.Parse(Console.ReadLine());
        //    var height = int.Parse(Console.ReadLine());
        //    IDrawable rect = new Rectangle(width, height);

        //    circle.Draw();
        //    rect.Draw();
        //}
        public static void Main()
        {
            ICar seat = new Seat("Leon", "Grey");
            ICar tesla = new Tesla("Model 3", "Red", 2);

            Console.WriteLine(seat.ToString());
            Console.WriteLine(tesla.ToString());
        }
    }
}
