using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDb.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Diagnoses = new List<Diagnose>();
            this.Visitations = new List<Visitation>();
            this.Prescriptions = new List<PatientMedicament>();
        }

        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MaxLength(80)]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }
               
        public virtual ICollection<Visitation> Visitations { get; set; }
               
        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
