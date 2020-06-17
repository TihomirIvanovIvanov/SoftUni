using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDb.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new List<Visitation>();
        }

        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
    }
}
