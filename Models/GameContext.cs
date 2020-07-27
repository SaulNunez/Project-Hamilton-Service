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
        public DbSet<Players> Players { get; set; }
        public DbSet<Items> Items { get; set; }

        public GameContext(DbContextOptions<GameContext> options)
    : base(options)
        { }
    }
}
