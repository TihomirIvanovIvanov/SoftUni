namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.PlayerStatistics = new HashSet<PlayerStatistic>();
            this.Bets = new HashSet<Bet>();
        }

        public int GameId { get; set; }
        public DateTime DateTime { get; set; }
        public float DrawBetRate { get; set; }
        public string Result { get; set; }

        public int HomeTeamId { get; set; }
        public byte HomeTeamGoals { get; set; }
        public decimal HomeTeamBetRate { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public byte AwayTeamGoals { get; set; }
        public decimal AwayTeamBetRate { get; set; }
        public Team AwayTeam { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
        public ICollection<Bet> Bets { get; set; }
    }
}
