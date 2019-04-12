namespace Ferrarii
{
    public class Ferrari : IDriveable
    {
        public Ferrari(string driverName)
        {
            this.DriverName = driverName;
            this.Model = "488-Spider";
        }

        public string Model { get; private set; }

        public string DriverName { get; private set; }

        public string Start()
        {
            return "Zadu6avam sA!";
        }

        public string Stop()
        {
            return "Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{Stop()}/{Start()}/{this.DriverName}";
        }
    }
}