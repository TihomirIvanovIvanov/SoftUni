using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class User
    {
        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Password { get; set; }
    }
}