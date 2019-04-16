namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        public int DoctorId { get; set; }

        public int Name { get; set; }

        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
