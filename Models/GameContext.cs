using LaCasaDelTerror.Assets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjectHamiltonService.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class GameContext: IdentityDbContext
    {
        static GameContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ThrowMotive>();
        }

        public DbSet<Lobbies> Lobbies { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Puzzles> Puzzles { get; set; }
        public DbSet<ThrowRequest> ThrowRequests { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasPostgresEnum<DiceThrow.ThrowTypes>();

            builder.HasPostgresEnum<ThrowMotive>();

            builder.Entity<Players>()
                .Property(x => x.X)
                .HasDefaultValue(0);

            builder.Entity<Players>()
                .Property(x => x.Y)
                .HasDefaultValue(0);

            builder.Entity<Players>()
                .Property(x => x.Floor)
                .HasDefaultValue(0);

            builder.Entity<Lobbies>()
                .Property(x => x.CreationTime)
                .HasDefaultValue(DateTime.Now);

            builder.Entity<Puzzles>()
                .Property(x => x.PuzzleStart)
                .HasDefaultValue(DateTime.Now);


            builder.Entity<Puzzles>().Property(x => x.NewX).HasDefaultValue(-1);
            builder.Entity<Puzzles>().Property(x => x.NewY).HasDefaultValue(-1);
            builder.Entity<Puzzles>().Property(x => x.NewFloor).HasDefaultValue(-1);

            builder.Entity<ThrowRequest>().Property(x => x.TimeOfRequest).HasDefaultValue(DateTime.Now);
        }
    }
}
