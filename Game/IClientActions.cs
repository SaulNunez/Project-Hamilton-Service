using ProjectHamiltonService.Game.ClientRequestModels;
using ProjectHamiltonService.Game.RequestModels;
using ProjectHamiltonService.Models;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public interface IClientActions
    {
        Task ChangeStats(ChangeStats newStats);
        //Task SetItemList(string playerName, List<LaCasaDelTerror.Assets.Items> items);
        //Task StartPuzzle(string xmlTemplate, string instructions);
        Task PlayerJoinedLobby();
        Task PlayerSelectedCharacter(NewPlayerInfo newPlayerInfo);
        Task StartGame(GamePrestartInformation playerOrderInformation);
        Task StartTurn(TurnRequest turnRequest);
        Task EndTurn();
        Task MoveCharacterToPosition(MovementRequest movementRequest);
        //Task PlayerMovementRequested(AvailableMovements availableMovements);
        Task GetItem(ItemObtainedUpdateRequest itemObtainedUpdateRequest);
        Task GetOmen(OmenObtainedUpdateRequest omenObtainedUpdateRequest);
        Task SolvePuzzle(ShowPuzzleRequest puzzleRequest);
        Task GetDirection(DirectionAvailability movements);
    }
}
