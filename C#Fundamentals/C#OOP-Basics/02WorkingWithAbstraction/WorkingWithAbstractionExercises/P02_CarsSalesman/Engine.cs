namespace P02_CarsSalesman
{
    public class Engine
    {
        private string model;
        private double power;
        private string displacement;
        private string efficiency;

        public Engine(string model, double power)
        {
            this.model = model;
            this.power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public string Model => this.model;

        public double Power => this.power;

        public string Displacement
        {
            get => this.displacement;
            set => this.displacement = value;
        }

        public string Efficiency
        {
            get => this.efficiency;
            set => this.efficiency = value;
        }
    }
}