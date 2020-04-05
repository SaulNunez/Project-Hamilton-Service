﻿using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    class Players: Character
    {
        public Players(Character characterPrototype)
        {
            name = characterPrototype.name;
            stats = characterPrototype.stats;
        }

        public List<Items> items;
        public Position position;
    }
}
