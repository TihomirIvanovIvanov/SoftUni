﻿using System;
using System.Collections.Generic;

namespace TeamBuilder.Models
{
    public class Event
    {
        public Event()
        {
            this.EventTeams = new HashSet<EventTeam>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CreatorId { get; set; }
        public User User { get; set; }

        public ICollection<EventTeam> EventTeams { get; set; }
    }
}
