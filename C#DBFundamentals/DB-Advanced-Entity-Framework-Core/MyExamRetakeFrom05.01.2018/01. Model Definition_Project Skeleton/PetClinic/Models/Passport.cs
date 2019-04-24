using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Passport
    {
        [Required]
        [RegularExpression(@"^([A-Za-z]{7})+(\d{3})$")]
        public string SerialNumber { get; set; }

        [Required]
        [RegularExpression(@"^(\+359|0)+(\d{9})$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [NotMapped]
        public int? AnimalId { get; set; }

        public Animal Animal { get; set; }
    }
}