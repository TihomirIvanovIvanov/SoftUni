namespace CarSalesman
{
    using System;
    using System.Text;

    public class Car
    {
        private string model;
        private Engine engine;
        private string weight;
        private string color;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }

        public string Weight
        {
            get { return this.weight; }
            set
            {
                if (value == null)
                {
                    this.weight = "n/a";
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        public string Color
        {
            get { return this.color; }
            set
            {
                if (value == null)
                {
                    this.color = "n/a";
                }
                else
                {
                    this.color = value;
                }
            }
        }

        public override string ToString()
        {
            var carModel = $"{this.Model}:";
            var engineModel = $"  {this.Engine.Model}:";
            var enginePower = $"    Power: {this.Engine.Power}";
            var engineDisplacement = $"    Displacement: {this.Engine.Displacement}";
            var engineEfficiency = $"    Efficiency: {this.Engine.Efficiency}";
            var carWeight = $"  Weight: {this.Weight}";
            var carColor = $"  Color: {this.Color}";

            var sb = new StringBuilder();
            sb.Append(carModel);
            sb.AppendLine();
            sb.Append(engineModel);
            sb.AppendLine();
            sb.Append(enginePower);
            sb.AppendLine();
            sb.Append(engineDisplacement);
            sb.AppendLine();
            sb.Append(engineEfficiency);
            sb.AppendLine();
            sb.Append(carWeight);
            sb.AppendLine();
            sb.Append(carColor);

            return sb.ToString();
        }
    }
}