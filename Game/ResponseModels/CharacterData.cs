using LaCasaDelTerror.Assets;
using LaCasaDelTerror.Assets.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ResponseModels
{
    public class CharacterData
    {
        public string Name { get; set; }
        public Stats Stats { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public CharacterData(Character character)
        {
            Name = character.name;
            Stats = character.stats;
            Description = character.description;
            Id = character.id;
        }
    }
}
