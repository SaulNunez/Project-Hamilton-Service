using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientRequestModels
{
    public class ChangeStats
    {
        public string PlayerName { get; set; }
        public Stats Stats { get; set; }
    }
}
