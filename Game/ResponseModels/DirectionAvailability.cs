using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Models
{
    public class DirectionAvailability
    {
        public static readonly DirectionAvailability None = new DirectionAvailability { 
            down = false, 
            up = false, 
            left = false, 
            right = false, 
            floorDown = false, 
            floorUp = false 
        };

        public bool right;
        public bool left;
        public bool up;
        public bool down;
        public bool floorUp;
        public bool floorDown;
    }
}
