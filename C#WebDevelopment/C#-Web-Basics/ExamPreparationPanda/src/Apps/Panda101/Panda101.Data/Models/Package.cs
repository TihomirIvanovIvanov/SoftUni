﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Panda101.Data.Models
{
    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Description { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; }

        public string EstimatedDeliveryDate { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public User Recipient { get; set; }
    }
}
