using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        protected Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public virtual string GetCarInfo()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(this.GetCarInfo())
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
