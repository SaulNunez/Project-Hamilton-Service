using ProjectHamiltonService.Game.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game.ClientRequestModels
{
    public class GamePrestartInformation
    {
        public List<CharacterOrder> PlayerOrder { get; set; }
        public RoomOrganization RoomPositions { get; set; }
    }
}
