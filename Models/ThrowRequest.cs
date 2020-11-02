using ProjectHamiltonService.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class ThrowRequest
    {
        public Guid Id { get; set; }
        public ThrowMotive Motive { get; set; }
        public DiceThrow.ThrowTypes Dice { get; set; }
        public Items? Item { get; set; }
        public Players Player { get; set; }
        public DateTime TimeOfRequest { get; private set; }
    }
}
