﻿namespace RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }

        public int Weight
        {
            get { return this.weight; }
            set { this.weight = value; }
        }

        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }


        //private int cargoWeight;
        //private string cargoType;

        //public Cargo(int cargoWeight, string cargoType)
        //{
        //    this.CargoWeight = cargoWeight;
        //    this.CargoType = cargoType;
        //}

        //public int CargoWeight
        //{
        //    get { return this.cargoWeight; }
        //    set { this.cargoWeight = value; }
        //}

        //public string CargoType
        //{
        //    get { return this.cargoType; }
        //    set { this.cargoType = value; }
        //}
    }
}