using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientRequestModels
{
    public class ThrowRequest : LobbyAction
    {
        public string PlayerToken { get; set; }
    }
}
