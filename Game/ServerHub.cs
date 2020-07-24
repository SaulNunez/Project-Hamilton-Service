using LaCasaDelTerror.Models;
using LaCasaDelTerror.Models.Abstracts;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game.ClientActions;
using ProjectHamiltonService.Game.ServerActions;
using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static LaCasaDelTerror.Models.Server;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        private GameContext gameContext;

        public ServerHub(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        private bool IsLobbyInList(string lobbyCode) => gameContext.Lobbies.Exists(x => x.Code == lobbyCode);

        private bool IsUserAuthCodeOfCurrentTurn(string lobbyCode, string playerToken)
        {
            var lobby = gameContext.Lobbies.Find(x => x.Code == lobbyCode);

            if(lobby != null)
            {
                return lobby.Players.Exists(x => x.PlayerToken == playerToken);
            }

            return false;
        }

        public DirectionAvailability GetAvailableMovements(LobbyAction action)
        {
            var lobby = gameContext.Lobbies.Find(x => x.Code == action.lobbyCode);

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

        public int Move(DirectionAction action)
        {
            if (IsUserAuthCodeOfCurrentTurn(action.lobbyCode, action.playerToken))
            {

                Players affectedPlayer; //gameContext.Lobbies.Find(action.lobbyCode).Players[currentMoveServerPlayerIndex];
                switch (action.Direction)
                {
                    case Direction.DOWN:
                        //affectedPlayer.Y--;
                        break;
                    case Direction.UP:
                        //affectedPlayer.Y++;
                        break;
                    case Direction.LEFT:
                        //affectedPlayer.X--;
                        break;
                    case Direction.RIGHT:
                        //affectedPlayer.X++;
                        break;
                }
                //affectedPlayer.PositionsMoved++;
                return 0; //affectedPlayer.CurrentThrow + affectedPlayer.PositionsMoved;
            }
            else
            {
                return -1;
            }
        }

        public async Task UseItem(ItemAction puzzleActions)
        {
            //Tener lista de items en player
            //Revisar si tiene item
            //Si si, afecta jugador que nos mando el shit
        }

        public List<Items> GetItems(LobbyAction lobby)
        {
            return new List<Items>();
        }

        private static readonly HttpClient client = new HttpClient();
        public async Task<bool> CheckPuzzle(PuzzleActions puzzleActions)
        {
            if (IsUserAuthCodeOfCurrentTurn(puzzleActions.lobbyCode, puzzleActions.playerToken))
            {
                //TODO: Cuando este terminada esa API llenar el JSON del request
                var values = new Dictionary<string, string>
                {
                { "code", puzzleActions.code },
                { "type", "world" }
                };

                var content = new FormUrlEncodedContent(values);

                //Cambiar dirección del servidor
                var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

                var responseString = await response.Content.ReadAsStringAsync();
            }

            return true;
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

        public bool SelectCharacter()
        {
            return true;
        }
    }
}
