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
        public List<Lobby> lobbies = new List<Lobby>();
    }
}
