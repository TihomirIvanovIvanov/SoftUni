﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.Models
{
    public class Procedure
    {
        public Procedure()
        {
            this.ProcedureAnimalAids = new HashSet<ProcedureAnimalAid>();
        }
        public int Id { get; set; }

        public int AnimalId { get; set; }

        [Required]
        public Animal Animal { get; set; }

        public int VetId { get; set; }

        [Required]
        public Vet Vet { get; set; }

        [NotMapped]
        public decimal Cost { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public ICollection<ProcedureAnimalAid> ProcedureAnimalAids { get; set; }
    }
}