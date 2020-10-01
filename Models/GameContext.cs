using LaCasaDelTerror.Assets;
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
        public DbSet<Puzzles> Puzzles { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Players>()
                .HasIndex(x => x.LobbyId)
                .IsUnique();

            builder.Entity<Players>()
                .HasIndex(x => x.CharacterPrototypeId)
                .IsUnique();

            builder.Entity<Players>()
                .Property(x => x.X)
                .HasDefaultValue(0);

            builder.Entity<Players>()
                .Property(x => x.Y)
                .HasDefaultValue(0);

            builder.Entity<Players>()
                .Property(x => x.Floor)
                .HasDefaultValue(0);
        }
    }
}
