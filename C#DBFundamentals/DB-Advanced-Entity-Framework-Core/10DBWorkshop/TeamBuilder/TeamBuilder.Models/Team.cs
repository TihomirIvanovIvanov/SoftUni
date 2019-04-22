using System.Collections.Generic;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Invitations = new HashSet<Invitation>();
            this.EventTeams = new HashSet<EventTeam>();
            this.UserTeams = new HashSet<UserTeam>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User User { get; set; }

        public ICollection<Invitation> Invitations { get; set; }
        public ICollection<EventTeam> EventTeams { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; }

    }
}
