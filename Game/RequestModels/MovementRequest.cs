using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.RequestModels
{
    public class MovementRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Floor { get; set; }
        public string Character { get; set; }
    }
}
