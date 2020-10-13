using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.RequestModels
{
    public class AvailableMovements
    {
        public bool CanGoUp { get; set; }
        public bool CanGoDown { get; set; }
        public bool CanGoLeft { get; set; }
        public bool CanGoRight { get; set; }
        public bool CanGoDownFloor { get; set; }
        public bool CanGoUpFloor { get; set; }
    }
}
