using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamBuilder.Models
{
    public class User
    {
        public User()
        {
            this.Invitations = new HashSet<Invitation>();
            this.Teams = new HashSet<Team>();
            this.Events = new HashSet<Event>();
        }
        public int Id { get; set; }

        [MinLength(3)]
        public string Username { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<Team> Teams { get; set; }
        public ICollection<Event> Events { get; set; }

    }
}
