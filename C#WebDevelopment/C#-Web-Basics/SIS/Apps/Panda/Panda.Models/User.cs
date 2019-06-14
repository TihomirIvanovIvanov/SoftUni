using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;

namespace Panda.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
        }

        public string Id { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Username must be between 5 and 20 charachres!")]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(5, 20, "Email must be between 5 and 20 charachres!")]
        public string Email { get; set; }

        [RequiredSis]
        public string Password { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
