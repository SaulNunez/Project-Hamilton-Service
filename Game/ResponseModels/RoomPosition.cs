﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ResponseModels
{
    public class RoomPosition
    {
        public string RoomId { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
