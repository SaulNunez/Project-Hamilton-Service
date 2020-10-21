using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientRequestModels
{
    public class CharacterOrder
    {
        public string CharacterName { get; set; }
        public int TurnThrow { get; set; }
        public int TurnOrder { get; set; }
    }
}
