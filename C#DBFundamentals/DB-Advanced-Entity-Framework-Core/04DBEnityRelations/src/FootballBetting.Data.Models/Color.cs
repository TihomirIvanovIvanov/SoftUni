using System.Collections.Generic;

namespace FootballBetting.Data.Models
{
    public class Color
    {
        public Color()
        {
            this.PrimaryKitTeams = new HashSet<Team>();
            this.SecondaryKitTeams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}