using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.RequestModels
{
    public class MovementRequest
    {
        public DirectionAvailability directionAvailability { get; set; }
    }
}
