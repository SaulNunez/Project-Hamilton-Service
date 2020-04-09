using LaCasaDelTerror.Models;
using LaCasaDelTerror.Models.Abstracts;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game.ClientActions;
using ProjectHamiltonService.Game.ServerActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        public int GoToLeft(LobbyAction action)
        {
            var availableMovements = Server.Instance.MoveHorizontal(action.lobbyCode, -1, action.code);

            var player = Server.Instance.lobbies[action.lobbyCode].GetPlayer();
            Clients.Group(action.lobbyCode).MoveTo(player.name, player.position);

            return availableMovements;
        }

        public int GoToRight(LobbyAction action)
        {
            var availableMovements = Server.Instance.MoveHorizontal(action.lobbyCode, 1, action.code);

            var player = Server.Instance.lobbies[action.lobbyCode].GetPlayer();
            Clients.Group(action.lobbyCode).MoveTo(player.name, player.position);

            return availableMovements;
        }

        public int GoToBottom(LobbyAction action)
        {
            var availableMovements = Server.Instance.MoveVertical(action.lobbyCode, -1, action.code);

            var player = Server.Instance.lobbies[action.lobbyCode].GetPlayer();
            Clients.Group(action.lobbyCode).MoveTo(player.name, player.position);

            return availableMovements;
        }

        public int GoToTop(LobbyAction action)
        {
            var availableMovements = Server.Instance.MoveVertical(action.lobbyCode, 1, action.code);

            var player = Server.Instance.lobbies[action.lobbyCode].GetPlayer();
            Clients.Group(action.lobbyCode).MoveTo(player.name, player.position);

            return availableMovements;
        }

        public async Task UseItem(ItemAction puzzleActions)
        {
            Server.Instance.UseItem(puzzleActions.lobbyCode, puzzleActions.code, puzzleActions.itemName);
        }

        public List<Items> GetItems(LobbyAction lobby)
        {
            return Server.Instance.GetItems(lobby.lobbyCode, lobby.code);
        }

        public async Task<bool> SendPuzzle(PuzzleActions puzzleActions)
        {
            return await Server.Instance.SolvePuzzle(puzzleActions.lobbyCode,
                puzzleActions.code,
                puzzleActions.puzzleResultCode);
        }

        public async Task<bool> EnterLobby(string code)
        {
            if (Server.Instance.lobbies.ContainsKey(code))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, code);
                Clients.Group(code).PlayerJoinedLobby();

                return true;
            }

            return false;
        }

        public List<Character> GetAvailableCharacters(LobbyAction lobby)
        {
            return Server.Instance.lobbies[lobby.lobbyCode].AvailableCharacters();
        }
    }
}
