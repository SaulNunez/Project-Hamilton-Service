using ProjectHamiltonService.Game.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaCasaDelTerror.Models
{
    public class Players: Character
    {
        public Players(Character characterPrototype)
        {
            name = characterPrototype.name;
            stats = characterPrototype.stats;
        }

        public List<Items> items;
        public Position position;
        public int floor;
        public int firstThrow;
        public int currentThrow;
        public int positionsMoved;
    }
}
