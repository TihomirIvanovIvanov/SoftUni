using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BattleCards.Models
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserCards = new HashSet<UserCard>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public virtual ICollection<UserCard> UserCards { get; set; }
    }
}
