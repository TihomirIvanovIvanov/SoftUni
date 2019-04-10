namespace RawData
{
    public class Engine
    {
        private int speed;
        private int power;

        public Engine(int speed, int power)
        {
            this.Speed = speed;
            this.Power = power;
        }
        public int Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public int Power
        {
            get { return this.power; }
            set { this.power = value; }
        }


        //private int engineSpeed = 0;
        //private int enginePower = 0;

        //public Engine(int engineSpeed, int enginePower)
        //{
        //    this.EngineSpeed = engineSpeed;
        //    this.EnginePower = enginePower;
        //}

        //public int EngineSpeed
        //{
        //    get { return this.engineSpeed; }
        //    set { this.engineSpeed = value; }
        //}

        //public int EnginePower
        //{
        //    get { return this.enginePower; }
        //    set { this.enginePower = value; }
        //}
    }
}