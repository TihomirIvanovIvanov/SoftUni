using SIS.MvcFramework.Attributes.Validation;
using System;

namespace Panda.Models
{
    public class Package
    {
        public Package()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Description must be between 5 and 20 charachres!")]
        public string Description  { get; set; }

        public decimal Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; } = PackageStatus.Pending;

        public DateTime EstimatedDeliveryDate { get; set; }

        [RequiredSis]
        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }
    }
}
