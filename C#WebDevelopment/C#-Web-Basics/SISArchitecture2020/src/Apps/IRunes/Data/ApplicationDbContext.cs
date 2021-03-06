﻿using IRunes.Models;
using Microsoft.EntityFrameworkCore;

namespace IRunes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=IRunesDb;Integrated Security=True;");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
