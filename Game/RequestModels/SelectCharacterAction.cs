using ProjectHamiltonService.Game.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ServerActions
{
    public class SelectCharacterAction: SimpleLobbyAction
    {
        public string character;
        public string name;
    }
}
