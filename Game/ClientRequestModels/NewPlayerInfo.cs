using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientRequestModels
{
    public class NewPlayerInfo
    {
        public string CharacterSelected { get; set; }
        public string LobbyName { get; set; }
        public Stats StartingStats {get; set; }
    }
}
