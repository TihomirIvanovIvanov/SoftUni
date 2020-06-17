using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDb.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new List<PatientMedicament>();
        }

        [Key]
        public int MedicamentId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
