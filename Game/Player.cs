﻿using LaCasaDelTerror.Models.Abstracts;
using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Players
    {
        public Players(Character characterPrototype)
        {
            Name = characterPrototype.name;
            Stats = characterPrototype.stats;
        }

        public string Name { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Floor { get; set; }

        public Stats Stats { get; set; }
        public List<Items> Items { get; set; }
        public int FirstThrow { get; set; }
        public int CurrentThrow { get; set; }
        public int PositionsMoved { get; set; }
        public string PlayerToken { get; set; }
    }
}
