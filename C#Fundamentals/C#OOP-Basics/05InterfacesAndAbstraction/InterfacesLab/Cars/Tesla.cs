namespace Cars
{
    public class Tesla : Car, ICar, IElectricCar
    {
        public Tesla(string model, string color, int batteries)
            : base(model, color)
        {
            this.Batteries = batteries;
        }

        public int Batteries { get; private set; }

        public override string GetCarInfo()
        {
            return base.GetCarInfo() + $" with {this.Batteries} Batteries";
        }
    }
}