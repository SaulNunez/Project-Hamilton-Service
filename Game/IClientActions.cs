using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaCasaDelTerror.Assets;
using LaCasaDelTerror.Assets.Abstracts;
using ProjectHamiltonService.Game.Abstracts;
using ProjectHamiltonService.Game.ClientRequestModels;
using ProjectHamiltonService.Game.RequestModels;
using ProjectHamiltonService.Models;

namespace ProjectHamiltonService.Game
{
    public interface IClientActions
    {
        Task ChangeStats(ChangeStats newStats);
        //Task SetItemList(string playerName, List<LaCasaDelTerror.Assets.Items> items);
        //Task StartPuzzle(string xmlTemplate, string instructions);
        Task PlayerJoinedLobby();
        Task PlayerSelectedCharacter(NewPlayerInfo newPlayerInfo);
        Task StartGame(PlayerOrderInformation playerOrderInformation);
        Task StartTurn(TurnRequest turnRequest);
        Task EndTurn();
        Task MoveCharacterToPosition(MovementRequest movementRequest);
        Task PlayerMovementRequested(AvailableMovements availableMovements);
        Task GetItem(ItemObtainedUpdateRequest itemObtainedUpdateRequest);
        Task GetOmen(OmenObtainedUpdateRequest omenObtainedUpdateRequest);
        Task SolvePuzzle(ShowPuzzleRequest puzzleRequest);
    }
}
