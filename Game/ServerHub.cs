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
using Microsoft.EntityFrameworkCore;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        private GameContext gameContext;

        public ServerHub(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        private bool IsLobbyInList(string lobbyCode) => gameContext.Lobbies.Any(x => x.Code == lobbyCode);

        private bool IsUserAuthCodeOfCurrentTurn(string lobbyCode, Guid playerToken)
        {
            var lobby = gameContext.Lobbies.Find(lobbyCode);

            if (lobby != null)
            {
                return lobby.Players.Exists(x => x.PlayerToken == playerToken);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lobbyCode">Codigo humano legible dado al lobby</param>
        /// <exception cref="LobbyNotExistsException">Aventara esta excepcion si este lobby no existe</exception>
        /// <returns></returns>
        private Lobbies GetLobby(string lobbyCode)
        {
            var lobby = gameContext.Lobbies.Find(lobbyCode);

            if (lobby != null)
            {
                return lobby;
            }
            else
            {
                throw new LobbyNotExistsException();
            }
        }

        public async Task<DirectionAvailability> GetAvailableMovementsAsync(LobbyAction action)
        {
            Lobbies lobby = GetLobby(action.lobbyCode);

            var player = lobby.Players.Find(x => x.PlayerToken == action.playerToken);

            var rooms = lobby.Rooms.Where(x => x.Floor == player.Floor);

            if(player.AvailableMovements <= 0)
            {
                return DirectionAvailability.None;
            }

            return new DirectionAvailability
            {
                right = (bool)(rooms?.Any(room => room.X == player.X + 1 && room.Y == player.Y)),
                left = (bool)(rooms?.Any(room => room.X == player.X - 1 && room.Y == player.Y)),
                up = (bool)(rooms?.Any(room => room.X == player.X && room.Y == player.Y + 1)),
                down = (bool)(rooms?.Any(room => room.X == player.X && room.Y == player.Y - 1)),
                floorUp = (bool)(rooms?.Where(room => room.X == player.X && room.Y == player.Y).First().MovesToFloor.Contains(player.Floor + 1)),
                floorDown = (bool)(rooms?.Where(room => room.X == player.X && room.Y == player.Y).First().MovesToFloor.Contains(player.Floor - 1))
            };
        }

        public async Task<MovementResult> MoveAsync(DirectionAction action)
        {
            if (IsUserAuthCodeOfCurrentTurn(action.lobbyCode, action.playerToken))
            {
                var lobby = GetLobby(action.lobbyCode);

                var player = lobby.Players.Find(player => player.PlayerToken == action.playerToken);

                var movementIsLegal = false;

                switch (action.Direction)
                {
                    case Direction.DOWN:
                        if(lobby.Rooms.Any(room => room.X == player.X && room.Y == player.Y - 1))
                        {
                            player.Y--;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.UP:
                        if (lobby.Rooms.Any(room => room.X == player.X && room.Y == player.Y + 1))
                        {
                            player.Y++;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.LEFT:
                        if (lobby.Rooms.Any(room => room.X == player.X - 1 && room.Y == player.Y))
                        {
                            player.X--;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.RIGHT:
                        if (lobby.Rooms.Any(room => room.X == player.X + 1 && room.Y == player.Y))
                        {
                            player.X++;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.FLOOR_DOWN:
                        break;
                    case Direction.FLOOR_UP:
                        break;
                }

                await gameContext.SaveChangesAsync();

                if (movementIsLegal)
                {
                    Clients.All.MoveCharacter(new PlayerUpdateResult
                    {
                        playerToken = action.playerToken,
                        x = player.X,
                        y = player.Y,
                        floor = player.Floor
                    });
                }

                return new MovementResult
                {
                    movementIsLegal = movementIsLegal,
                    floor = player.Floor,
                    x = player.X,
                    y = player.Y
                };
            }

            return null;
        }

        public async Task UseItem(ItemAction action)
        {
            //Tener lista de items en player
            //Revisar si tiene item
            //Si si, afecta jugador que nos mando el shit
        }

        public List<Items> GetItems(LobbyAction action)
        {
            var lobby = GetLobby(action.lobbyCode);

            var player = lobby.Players.Find(x => x.PlayerToken == action.playerToken);

            return player.Items;
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
