using System.Collections.Generic;

namespace FootballBetting.Data.Models
{
    public class Position
    {
        public Position()
        {
            this.Players = new HashSet<Player>();
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}