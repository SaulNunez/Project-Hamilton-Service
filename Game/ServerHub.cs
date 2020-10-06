using LaCasaDelTerror.Assets;
using LaCasaDelTerror.Assets.Abstracts;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game.ClientActions;
using ProjectHamiltonService.Game.ServerActions;
using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static LaCasaDelTerror.Assets.Server;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Items = LaCasaDelTerror.Assets.Items;
using System.Net;
using RestSharp;
using ProjectHamiltonService.Game.RequestModels;
using ProjectHamiltonService.Game.ResponseModels;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        private GameContext gameContext;

        public ServerHub(GameContext gameContext)
        {
            this.gameContext = gameContext;
        }

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
                    //Clients.All.MoveCharacter(new PlayerUpdateResult
                    //{
                    //    playerToken = action.playerToken,
                    //    x = player.X,
                    //    y = player.Y,
                    //    floor = player.Floor
                    //});
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
            var item = gameContext.Items.Find(Guid.Parse(action.itemId));

            if(item != null)
            {
                var itemPrototype = Items.items.Find(x => item.Prototype == x.id);

                if(itemPrototype.specialItem == Items.SpecialEffect.LADDER)
                {

                }

                if(itemPrototype.statEffects != null)
                {
                    Models.Players players;
                    if (action.characterToAffect != null) {
                        players = gameContext.Players.Where(x => x.Name == action.characterToAffect && x.LobbyId == action.lobbyCode).FirstOrDefault();
                    } else
                    {
                        players = gameContext.Players.Find(action.playerToken);
                    }

                    players.Bravery += itemPrototype.statEffects.Bravery;
                    players.Intelligence += itemPrototype.statEffects.Intelligence;
                    players.Sanity += itemPrototype.statEffects.Sanity;
                    players.Physical += itemPrototype.statEffects.Physical;
                }

                if (itemPrototype.singleUse)
                {
                    gameContext.Remove(item);
                }
            }
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
            var protoInfo = itemsOnPlayer.Select(x => Items.items.Where(y => y.id == x.Prototype).First()).ToList();

            return protoInfo;
        }

        private static readonly HttpClient client = new HttpClient();
        public PuzzleResult CheckPuzzle(PuzzleActions puzzleActions)
        {
            var lobby = gameContext.Lobbies.Find(puzzleActions.lobbyCode);
            var puzzle = gameContext.Puzzles.Find(puzzleActions.puzzleId);

            var puzzlePrototype = Puzzles.puzzles.Find(x => x.id == puzzle.PuzzlePrototype);

            if (lobby.CurrentPlayer.Id == puzzleActions.playerToken && puzzle.PlayersId == puzzleActions.playerToken)
            {
                var requestPayload = new PuzzleCheckRequest(puzzleActions.code, puzzlePrototype.expectedOutput,
                    puzzlePrototype.type,
                    new List<PuzzleFunctionCheck> { },
                    puzzlePrototype.functionsExpected);

                var client = new RestClient("https://hamilton-microservice.herokuapp.com/");
                var request = new RestRequest()
                {
                    Method = Method.POST,
                    RequestFormat = DataFormat.Json
                };

                request.AddJsonBody(requestPayload);
                var response = client.Execute(request);
                var responseString = response.Content;
                var result = JsonSerializer.Deserialize<CodeTestResult>(responseString);

                var correct = result.matchesOutput && result.passedCheck && result.hasFunctions && result.passedFunctionChecks;
                var output = String.Join("\n", result.runOutput);

                puzzle.SolvedCorrectly = correct;
                puzzle.PuzzleEnd = DateTime.Now;

                if (correct)
                {
                    //TODO: Ver que consecuencias tiene que se haya resuelto el puzzle y encadenarlas aqui
                }

                return new PuzzleResult
                {
                    correct = correct,
                    output = output
                };
            }

            return new PuzzleResult { correct = false, output = "" };
        }

        public async Task<bool> EnterLobby(string code)
        {
            if (gameContext.Lobbies.Find(code) != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, code);
                //await Clients.Group(code).PlayerJoinedLobby();

                return true;
            }

            return false;
        }

        public Task<AvailableCharactersResult> GetAvailableCharacters(SimpleLobbyAction lobby)
        {
            var currentPlayers = gameContext.Players.Where(x => x.LobbyId == lobby.lobbyCode);
            var charactersAvailable = Character.roster
                .Where(x => currentPlayers.FirstOrDefault(y => y.CharacterPrototypeId == x.id) == null);

            return Task.FromResult(new AvailableCharactersResult(charactersAvailable.ToList()));
        }

        public Task<PlayerSelectionResult> SelectCharacter(SelectCharacterAction action)
        {
            var currentPlayers = gameContext.Players.Where(x => x.LobbyId == action.lobbyCode && x.CharacterPrototypeId == action.Character);
            if (currentPlayers.Count() > 0)
            {
                Console.WriteLine("Player is in lobby");
                return null;
            }

            var characterPrototype = Character.roster.Find(x => x.id == action.Character);

            var newPlayer = new Models.Players
            {
                Bravery = characterPrototype.stats.Bravery,
                Intelligence = characterPrototype.stats.Intelligence,
                Sanity = characterPrototype.stats.Sanity,
                Physical = characterPrototype.stats.Physical,

                Name = action.Name,
                CharacterPrototypeId = action.Character
            };

            gameContext.Add(newPlayer);

            gameContext.SaveChanges();

            var response = new PlayerSelectionResult
            {
                PlayerToken = newPlayer.Id.ToString()
            };

            return Task.FromResult(response);
        }
    }
}
