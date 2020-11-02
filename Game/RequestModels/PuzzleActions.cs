using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientActions
{
    public class PuzzleActions: LobbyAction
    {
#nullable enable
        public string Code { get; set; }
        public string PuzzleId { get; set; }
        public string? AffectsCharacter { get; set; }
#nullable disable
    }
}
