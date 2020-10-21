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
        public int Dice { get; set; }
    }
}
