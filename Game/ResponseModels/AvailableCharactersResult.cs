using LaCasaDelTerror.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ResponseModels
{
    public class AvailableCharactersResult
    {
        public AvailableCharactersResult(List<Character> available)
        {
            this.Available = available.Select(x => new CharacterData(x)).ToList();
        }
        public List<CharacterData> Available { get; set; }
    }
}
