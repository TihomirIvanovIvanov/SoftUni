namespace SpeedRacing
{
    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumption;

        private double travelDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }

        public double TravelDistance
        {
            get { return travelDistance; }
            set { travelDistance = value; }
        }

        public bool IsFuelEnough(int distance)
        {
            if (this.FuelConsumption * distance <= this.FuelAmount)
            {
                this.FuelAmount -= this.FuelConsumption * distance;
                this.TravelDistance += distance;
                return true;
            }
            return false;
        }
    }
}
