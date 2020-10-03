using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaCasaDelTerror.Assets;
using LaCasaDelTerror.Assets.Abstracts;
using ProjectHamiltonService.Game.Abstracts;

namespace ProjectHamiltonService.Game
{
    public interface IClientActions
    {
        Task ChangeStats(string playerName, Stats stats);
        Task SetItemList(string playerName, List<Items> items);
        Task MoveCharacter(PlayerUpdateResult result);
        Task StartPuzzle(string xmlTemplate, string instructions);
        Task PlayerJoinedLobby();
        Task CharacterJoined();
        Task StartGame();
    }
}
