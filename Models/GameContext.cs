using LaCasaDelTerror.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class GameContext: DbContext
    {
        public DbSet<Lobbies> Lobbies { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Rooms> Rooms { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Players>()
                .HasIndex(x => x.lobbyId)
                .IsUnique();

            builder.Entity<Players>()
                .HasIndex(x => x.characterPrototypeId)
                .IsUnique();

            builder.Entity<Players>()
                .Property(x => x.x)
                .HasDefaultValue(0);
            builder.Entity<Players>()
                .Property(x => x.y)
                .HasDefaultValue(0);
            builder.Entity<Players>()
                .Property(x => x.floor)
                .HasDefaultValue(0);

        }
    }
}
