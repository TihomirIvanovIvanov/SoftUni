using System.ComponentModel.DataAnnotations;

namespace HospitalDb.Models
{
    public class PatientMedicament
    {
        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int MedicamentId { get; set; }

        public Medicament Medicament { get; set; }
    }
}
