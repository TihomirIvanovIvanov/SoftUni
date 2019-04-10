namespace P04_Hospital
{
    using System.Collections.Generic;

    public class Doctor
    {
        private string firstName;
        private string lastName;
        private List<string> patients;

        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Patients = new List<string>();
        }

        public string FirstName
        {
            get => this.firstName;
            set => this.firstName = value;
        }

        public string LastName
        {
            get => this.lastName;
            set => this.lastName = value;
        }

        public List<string> Patients
        {
            get => this.patients;
            set => this.patients = value;
        }
    }
}