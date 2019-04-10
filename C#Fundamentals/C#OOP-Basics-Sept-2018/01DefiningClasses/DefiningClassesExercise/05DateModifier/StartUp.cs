namespace _05DateModifier
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();

            var modifier = new DateModifier();
            modifier.CalculateDifference(startDate, endDate);
            Console.WriteLine(modifier.Difference);
        }
    }
}