using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IGameServer>
    {
        public async Task<bool> GoToLeft()
        {

        }

        public async Task<bool> GoToRight()
        {

        }

        public async Task<bool> GoToBottom()
        {

        }

        public async Task<bool> GoToTop()
        {

        }

        public async Task UseItem()
        {

        }

        public async Task<List<Items>> GetItems()
        {

        }

        public async Task SendPuzzle()
        {

        }

        public async Task EnterLobby(string code)
        {

        }

        public async Task<Character> GetAvailableCharacters()
        {

        }

        public async Task GetStatsForCharacter(string? character = null)
        {

        }
    }
}
