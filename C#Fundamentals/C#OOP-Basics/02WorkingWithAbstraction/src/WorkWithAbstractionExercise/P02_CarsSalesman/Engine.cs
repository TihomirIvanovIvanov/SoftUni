namespace P02_CarsSalesman
{
    public  class Engine
    {
        public string model;

        public double power;

        public string displacement;

        public string efficiency;

        public Engine(string model, double power)
        {
            this.model = model;
            this.power = power;
            this.Displacement = "n/a";
            this.Efficiency = "n/a";
        }

        public string Model => this.model;

        public double Power => this.power;

        public string Displacement { get; set; }

        public string Efficiency { get; set; }
    }
}
