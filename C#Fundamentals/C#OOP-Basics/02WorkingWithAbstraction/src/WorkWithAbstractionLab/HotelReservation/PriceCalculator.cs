using System;

namespace HotelReservation
{
    public class PriceCalculator
    {
        private readonly decimal pricePerNight;

        private readonly int nights;

        private readonly Seasons seasons;

        private readonly Discounts discounts;

        public PriceCalculator(string command)
        {
            var splitCommand = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            this.pricePerNight = decimal.Parse(splitCommand[0]);
            this.nights = int.Parse(splitCommand[1]);
            this.seasons = Enum.Parse<Seasons>(splitCommand[2]);
            this.discounts = Discounts.None;

            if (splitCommand.Length > 3)
            {
                this.discounts = Enum.Parse<Discounts>(splitCommand[3]);
            }
        }

        public string CalculatePrice()
        {
            var tempTotal = this.pricePerNight * this.nights * (int)this.seasons;
            var discountPercentage = ((decimal)100 - (int)this.discounts) / 100;
            var totalPrice = tempTotal * discountPercentage;
            return totalPrice.ToString("F2");
        }
    }
}
