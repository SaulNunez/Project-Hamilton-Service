using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientActions
{
    public class PuzzleActions: LobbyAction
    {
        public string Code { get; set; }
        public string PuzzleId { get; set; }
    }
}
