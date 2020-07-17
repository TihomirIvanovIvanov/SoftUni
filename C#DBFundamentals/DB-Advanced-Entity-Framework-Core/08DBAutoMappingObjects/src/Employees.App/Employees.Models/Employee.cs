using System;
using System.ComponentModel.DataAnnotations;

namespace Employees.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }
    }
}
