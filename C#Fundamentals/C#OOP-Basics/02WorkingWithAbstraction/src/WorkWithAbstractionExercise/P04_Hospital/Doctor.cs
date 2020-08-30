using System.Collections.Generic;

namespace P04_Hospital
{
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

        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }

        public List<string> Patients { get => patients; set => patients = value; }
    }
}