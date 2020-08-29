using System.Text;

namespace P02_CarsSalesman
{
    public  class Car
    {
        public string model;

        public Engine engine;

        public string weight;

        public string color;

        public Car(string model, Engine engine)
        {
            this.model = model;
            this.engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public string Model => this.model;

        public Engine Engine => this.engine;

        public string Weight { get; set; }

        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder()
                .AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine.Model}:")
                .AppendLine($"    Power: {this.Engine.Power}")
                .AppendLine($"    Displacement: {this.Engine.Displacement}")
                .AppendLine($"    Efficiency: {this.Engine.Efficiency}")
                .AppendLine($"  Weight: {this.Weight}")
                .AppendLine($"  Color: {this.Color}");

            return sb.ToString().TrimEnd();
        }
    }

}
