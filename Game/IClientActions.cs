using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaCasaDelTerror.Assets;
using LaCasaDelTerror.Assets.Abstracts;
using ProjectHamiltonService.Game.Abstracts;
using ProjectHamiltonService.Game.RequestModels;
using ProjectHamiltonService.Models;

namespace ProjectHamiltonService.Game
{
    public interface IClientActions
    {
        Task ChangeStats(string playerName, Stats stats);
        Task SetItemList(string playerName, List<LaCasaDelTerror.Assets.Items> items);
        Task StartPuzzle(string xmlTemplate, string instructions);
        Task PlayerJoinedLobby();
        Task CharacterJoined();
        Task StartGame();
        Task StartTurn();
        Task MoveCharacterToPosition(MovementRequest movementRequest);
        Task PlayerMovementRequested(AvailableMovements availableMovements);
        Task GetItem(ItemObtainedUpdateRequest itemObtainedUpdateRequest);
        Task GetOmen(OmenObtainedUpdateRequest omenObtainedUpdateRequest);
        Task SolvePuzzle(ShowPuzzleRequest puzzleRequest);
    }
}
