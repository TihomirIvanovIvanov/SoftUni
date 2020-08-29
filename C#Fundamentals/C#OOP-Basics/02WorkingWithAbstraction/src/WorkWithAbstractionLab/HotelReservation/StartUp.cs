using System;

namespace HotelReservation
{
    public class StartUp
    {
        public static void Main()
        {
            var command = Console.ReadLine();
            var priceCalc = new PriceCalculator(command);
            var totalPrice = priceCalc.CalculatePrice();
            Console.WriteLine(totalPrice);
        }
    }
}
