using LaCasaDelTerror.Models;
using LaCasaDelTerror.Models.Abstracts;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game.ClientActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        public async Task<bool> GoToLeft(LobbyAction action)
        {

        }

        public async Task<bool> GoToRight(LobbyAction action)
        {
            
        }

        public async Task<bool> GoToBottom(LobbyAction action)
        {

        }

        public async Task<bool> GoToTop(LobbyAction action)
        {

        }

        public async Task UseItem()
        {

        }

        public List<Items> GetItems(LobbyAction lobby)
        {
            return Server.Instance.GetItems(lobby.lobbyCode, lobby.code);
        }

        public async Task<bool> SendPuzzle(PuzzleActions puzzleActions)
        {

        }

        public async Task<bool> EnterLobby(string code)
        {
            //TODO: Revisar que contiene lobbies
            if (Server.Instance.lobbies.ContainsKey(code))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, code);

                return true;
            }

            return false;
        }

        public async Task<List<Character>> GetAvailableCharacters(LobbyAction lobby)
        {

        }

        public async Task<Stats> GetStatsForCharacter(string? character = null)
        {

        }
    }
}
