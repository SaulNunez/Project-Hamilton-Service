using LaCasaDelTerror.Models;
using LaCasaDelTerror.Models.Abstracts;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game.ClientActions;
using ProjectHamiltonService.Game.ServerActions;
using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        private GameContext gameContext;

        public ServerHub(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        private bool IsLobbyInList(string lobbyCode) => gameContext.lobbies.Exists(x => x.code == lobbyCode);

        private bool IsUserAuthCodeOfCurrentTurn(string lobbyCode, string playerToken)
        {
            var lobby = gameContext.lobbies.Find(x => x.code == lobbyCode);

            if(lobby != null)
            {
                return lobby.players.Exists(x => x.code == playerToken);
            }

            return false;
        }

        public DirectionAvailability GetAvailableMovements(LobbyAction action)
        {
            var lobby = gameContext.lobbies.Find(x => x.code == action.lobbyCode);

            if (lobby != null)
            {
                return new DirectionAvailability
                {
                    right = false,
                    left = false,
                    up = false,
                    down = false
                };
            }

            return null;
        }

        public int Move(LobbyAction action)
        {

            return 1;
        }

        public async Task UseItem(ItemAction puzzleActions)
        {
            
        }

        public List<Items> GetItems(LobbyAction lobby)
        {
            return new List<Items>();
        }

        public async Task<bool> SendPuzzle(PuzzleActions puzzleActions)
        {
            return false;
        }

        public async Task<bool> EnterLobby(string code)
        {
            //Existe lobby en servidor
            if (true)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, code);
                Clients.Group(code).PlayerJoinedLobby();

                return true;
            }

            return false;
        }

        public List<Character> GetAvailableCharacters(LobbyAction lobby)
        {
            return new List<Character>();
        }
    }
}
