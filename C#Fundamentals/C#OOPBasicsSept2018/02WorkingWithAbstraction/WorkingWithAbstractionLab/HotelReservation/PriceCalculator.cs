namespace HotelReservation
{
    using Enums;
    using System;

    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int nights;
        private Seasons season;
        private Discounts discount;

        public PriceCalculator(string command)
        {
            var splitCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            this.pricePerNight = decimal.Parse(splitCommand[0]);
            this.nights = int.Parse(splitCommand[1]);
            this.season = Enum.Parse<Seasons>(splitCommand[2]);
            this.discount = Discounts.None;

            if (splitCommand.Length > 3)
            {
                discount = Enum.Parse<Discounts>(splitCommand[3]);
            }
        }

        public string CalculatePrice()
        {
            var tempTotal = this.pricePerNight * this.nights * (int)this.season;
            var discountPercentage = ((decimal)100 - (int)this.discount) / 100;
            var totalPrice = tempTotal * discountPercentage;
            return totalPrice.ToString("F2");
        }
    }
}