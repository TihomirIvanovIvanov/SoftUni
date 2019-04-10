﻿namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Room
    {
        private List<string> patients;

        public Room()
        {
            this.Patients = new List<string>();
        }

        public List<string> Patients
        {
            get => this.patients;
            set => this.patients = value;
        }
    }
}