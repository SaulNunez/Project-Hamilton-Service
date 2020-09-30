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
using System.Text.Json;
using Items = LaCasaDelTerror.Models.Items;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        private GameContext gameContext;

        public ServerHub(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        //private bool IsLobbyInList(string lobbyCode) => gameContext.Lobbies.Any(x => x.Code == lobbyCode);

        //private bool IsUserAuthCodeOfCurrentTurn(string lobbyCode, Guid playerToken)
        //{
        //    var lobby = gameContext.Lobbies.Find(lobbyCode);

        //    if (lobby != null)
        //    {
        //        return lobby.Players.Exists(x => x.PlayerToken == playerToken);
        //    }

        //    return false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="lobbyCode">Codigo humano legible dado al lobby</param>
        ///// <exception cref="LobbyNotExistsException">Aventara esta excepcion si este lobby no existe</exception>
        ///// <returns></returns>
        //private Lobbies GetLobby(string lobbyCode)
        //{
        //    var lobby = gameContext.Lobbies.Find(lobbyCode);

        //    if (lobby != null)
        //    {
        //        return lobby;
        //    }
        //    else
        //    {
        //        throw new LobbyNotExistsException();
        //    }
        //}

        public DirectionAvailability GetAvailableMovements(LobbyAction action)
        {
            var lobby = gameContext.Lobbies.Find(action.lobbyCode);

            var player = gameContext.Players.Find(action.playerToken);

            var rooms = gameContext.Rooms.Where(r => r.Floor == player.Floor && r.X == player.X && r.Y == player.Y).First();

            if (player.AvailableMoves <= 0)
            {
                return DirectionAvailability.None;
            }

            return new DirectionAvailability
            {
                right = gameContext.Rooms.Any(room => room.X == player.X + 1 && room.Y == player.Y),
                left = gameContext.Rooms.Any(room => room.X == player.X - 1 && room.Y == player.Y),
                up = gameContext.Rooms.Any(room => room.X == player.X && room.Y == player.Y + 1),
                down = gameContext.Rooms.Any(room => room.X == player.X && room.Y == player.Y - 1),
                //floorUp = (bool)(gameContext.Rooms.Where(room => room.x == player.x && room.y == player.y).First().MovesToFloor.Contains(player.Floor + 1)),
                //floorDown = (bool)(gameContext.Rooms.Where(room => room.x == player.x && room.y == player.y).First().MovesToFloor.Contains(player.Floor - 1))
            };
        }

        public async Task<MovementResult> MoveAsync(DirectionAction action)
        {
            var lobby = gameContext.Lobbies.Find(action.lobbyCode);

            if (lobby != null && lobby.CurrentPlayer.Id == action.playerToken)
            {
                var player = gameContext.Players.Find(action.playerToken);

                var movementIsLegal = false;

                switch (action.Direction)
                {
                    case Direction.DOWN:
                        if (gameContext.Rooms.Any(room => room.X == player.X && room.Y == player.Y - 1))
                        {
                            player.Y--;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.UP:
                        if (gameContext.Rooms.Any(room => room.X == player.X && room.Y == player.Y + 1))
                        {
                            player.Y++;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.LEFT:
                        if (gameContext.Rooms.Any(room => room.X == player.X - 1 && room.Y == player.Y))
                        {
                            player.X--;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.RIGHT:
                        if (gameContext.Rooms.Any(room => room.X == player.X + 1 && room.Y == player.Y))
                        {
                            player.X++;
                            movementIsLegal = true;
                        }
                        break;
                    case Direction.FLOOR_DOWN:
                        //if (gameContext.Rooms.Where(room => room.X == player.X && room.Y == player.Y).First().MovesToFloor.Contains(player.Floor + 1))
                        //{
                        //    player.Floor--;
                        //    movementIsLegal = true;
                        //}
                        break;
                    case Direction.FLOOR_UP:
                        //if (gameContext.Rooms.Where(room => room.X == player.X && room.Y == player.Y).First().MovesToFloor.Contains(player.Floor - 1))
                        //{
                        //    player.Floor++;
                        //    movementIsLegal = true;
                        //}
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

            //TODO: Revisar todas las posibilidades que tienen los items
        }

        public List<Items> GetItems(LobbyAction action)
        {
            var lobby = gameContext.Lobbies.Find(action.lobbyCode);

            if(lobby == null)
            {
                return null;
            }
            var itemsOnPlayer = gameContext.Items.Where(x => x.PlayersId == action.playerToken);
            //Tal vez no sea tan rapido, luego hacer profiling
            var protoInfo = itemsOnPlayer.Select(x => Items.items.Where(y => y.Key == x.Prototype).First()).Select(x => x.Value).ToList();

            return protoInfo;
        }

        private static readonly HttpClient client = new HttpClient();
        public async Task<bool> CheckPuzzleAsync(PuzzleActions puzzleActions)
        {
            var lobby = gameContext.Lobbies.Find(puzzleActions.lobbyCode);

            if (lobby.CurrentPlayer.Id == puzzleActions.playerToken)
            {
                //TODO: Cuando este terminada esa API llenar el JSON del request
                var values = new Dictionary<string, string>
                {
                { "code", puzzleActions.code },
                { "type", "world" }
                };

                var content = new FormUrlEncodedContent(values);

                //Cambiar dirección del servidor
                var response = await client.PostAsync("https://hamilton-microservice.herokuapp.com/", content);

                var responseString = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<CodeTestResult>(responseString);
            }

            return true;
        }

        public async Task<bool> EnterLobby(string code)
        {
            if (gameContext.Lobbies.Find(code) != null)
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

        //public bool SelectCharacter()
        //{
        //    return true;
        //}
    }
}
