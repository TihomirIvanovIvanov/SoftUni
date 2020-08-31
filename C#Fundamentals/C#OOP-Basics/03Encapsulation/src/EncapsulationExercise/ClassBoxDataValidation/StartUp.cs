using System;

namespace ClassBoxDataValidation
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var height = double.Parse(Console.ReadLine());

                var box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurface():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
