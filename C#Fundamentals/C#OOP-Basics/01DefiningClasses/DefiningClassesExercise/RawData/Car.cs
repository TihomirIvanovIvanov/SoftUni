namespace RawData
{
    using System.Collections.Generic;

    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tyre> tyres;

        public Car(string model, Engine engine, Cargo cargo, List<Tyre> tyres)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }

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

        public Cargo Cargo
        {
            get { return this.cargo; }
            set { this.cargo = value; }
        }

        public List<Tyre> Tyres
        {
            get { return this.tyres; }
            set { this.tyres = value; }
        }


        //private string model;
        //private Engine engine;
        //private Cargo cargo;
        //private List<Tyre> tyres;

        //public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType,
        //           double tyre1Pressure, int tyre1Age,
        //           double tyre2Pressure, int tyre2Age,
        //           double tyre3Pressure, int tyre3Age,
        //           double tyre4Pressure, int tyre4Age)
        //{
        //    this.Model = model;
        //    this.Engine = new Engine(engineSpeed, enginePower);
        //    this.Cargo = new Cargo(cargoWeight, cargoType);
        //    this.Tyres = new List<Tyre>();

        //    Tyre firstTyre = new Tyre(tyre1Pressure, tyre1Age);
        //    this.Tyres.Add(firstTyre);

        //    Tyre secondTyre = new Tyre(tyre2Pressure, tyre2Age);
        //    this.Tyres.Add(secondTyre);

        //    Tyre thirdTyre = new Tyre(tyre3Pressure, tyre3Age);
        //    this.Tyres.Add(thirdTyre);

        //    Tyre fourthTyre = new Tyre(tyre4Pressure, tyre4Age);
        //    this.Tyres.Add(fourthTyre);
        //}

        //public string Model
        //{
        //    get { return this.model; }
        //    set { this.model = value; }
        //}

        //public Engine Engine
        //{
        //    get { return this.engine; }
        //    set { this.engine = value; }
        //}

        //public Cargo Cargo
        //{
        //    get { return this.cargo; }
        //    set { this.cargo = value; }
        //}

        //public List<Tyre> Tyres
        //{
        //    get { return this.tyres; }
        //    set { this.tyres = value; }
        //}
    }
}