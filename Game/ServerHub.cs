using LaCasaDelTerror.Assets;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game.ClientActions;
using ProjectHamiltonService.Game.ServerActions;
using ProjectHamiltonService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static LaCasaDelTerror.Assets.Server;
using System.Text.Json;
using Items = LaCasaDelTerror.Assets.Items;
using RestSharp;
using ProjectHamiltonService.Game.RequestModels;
using ProjectHamiltonService.Game.ResponseModels;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Rooms = LaCasaDelTerror.Assets.Rooms;

namespace ProjectHamiltonService.Game
{
    public class ServerHub : Hub<IClientActions>
    {
        private readonly GameContext gameContext;
        private readonly DiceThrow diceThrow;
        private readonly UserManager<IdentityUser> userManager;

        public ServerHub(GameContext gameContext, DiceThrow diceThrow, UserManager<IdentityUser> userManager)
        {
            this.gameContext = gameContext;
            this.diceThrow = diceThrow;
            this.userManager = userManager;
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
                right = lobby.Rooms.Any(room => room.X == player.X + 1 && room.Y == player.Y),
                left = lobby.Rooms.Any(room => room.X == player.X - 1 && room.Y == player.Y),
                up = lobby.Rooms.Any(room => room.X == player.X && room.Y == player.Y + 1),
                down = lobby.Rooms.Any(room => room.X == player.X && room.Y == player.Y - 1),
                floorUp = lobby.Rooms
                    .Where(room => room.X == player.X && room.Y == player.Y)
                    .Select(rm => Rooms.FindRoom((Rooms.HouseFloors)rm.Floor, rm.RoomProtoype))
                    .First().MovesToFloor
                    .Contains(player.Floor + 1),
                floorDown = lobby.Rooms
                    .Where(room => room.X == player.X && room.Y == player.Y)
                    .Select(rm => Rooms.FindRoom((Rooms.HouseFloors)rm.Floor, rm.RoomProtoype))
                    .First()
                    .MovesToFloor.Contains(player.Floor - 1)
            };
        }

        public async Task<MovementResult> Move(DirectionAction action)
        {
            var lobby = gameContext.Lobbies.Find(action.lobbyCode);

            if (lobby != null && lobby.CurrentPlayerId == action.playerToken)
            {
                var player = gameContext.Players.Find(action.playerToken);

                Models.Rooms rooms = null;
                switch (action.MoveDirection)
                {
                    case Direction.Down:
                        rooms = lobby.Rooms.Where(room => room.X == player.X && room.Y == player.Y - 1).First();
                        if (lobby.Rooms.Any(room => room.X == player.X && room.Y == player.Y - 1))
                        {
                            player.Y--;
                        }
                        break;
                    case Direction.Up:
                        rooms = lobby.Rooms.Where(room => room.X == player.X && room.Y == player.Y + 1).First();
                        if (lobby.Rooms.Any(room => room.X == player.X && room.Y == player.Y + 1))
                        {
                            player.Y++;
                        }
                        break;
                    case Direction.Left:
                        rooms = lobby.Rooms.Where(room => room.X == player.X - 1 && room.Y == player.Y).First();
                        if (lobby.Rooms.Any(room => room.X == player.X - 1 && room.Y == player.Y))
                        {
                            player.X--;
                        }
                        break;
                    case Direction.Right:
                        rooms = lobby.Rooms.Where(room => room.X == player.X + 1 && room.Y == player.Y).First();
                        if (lobby.Rooms.Any(room => room.X == player.X + 1 && room.Y == player.Y))
                        {
                            player.X++;
                        }
                        break;
                    case Direction.DownFloor:
                        var currentRoomModel = lobby.Rooms.Where(room => room.X == player.X && room.Y == player.Y).First();
                        Rooms roomPrototype = Rooms.FindRoom((Rooms.HouseFloors)currentRoomModel.Floor, currentRoomModel.RoomProtoype);

                        if (roomPrototype != null)
                        {
                            if(roomPrototype.MovesToFloor.Contains(player.Floor - 1))
                            {
                                player.Floor--;
                                if (roomPrototype.MovesToRoom != null)
                                {
                                    var newRoom = lobby.Rooms.Where(room => room.RoomProtoype == roomPrototype.MovesToRoom && room.Floor == player.Floor).FirstOrDefault();
                                    player.X = newRoom.X;
                                    player.Y = newRoom.Y;
                                }
                            }

                            if(roomPrototype.MovesToPositionX != null && roomPrototype.MovesToPositionY != null)
                            {
                                player.Floor--;
                                player.X = roomPrototype.MovesToPositionX.Value;
                                player.Y = roomPrototype.MovesToPositionY.Value;
                            }
                        }
                        break;
                    case Direction.UpFloor:
                        var currentRoomModelTop = lobby.Rooms.Where(room => room.X == player.X && room.Y == player.Y).First();
                        Rooms roomPrototypeTop = Rooms.FindRoom((Rooms.HouseFloors)currentRoomModelTop.Floor, currentRoomModelTop.RoomProtoype);

                        if (roomPrototypeTop != null)
                        {
                            if (roomPrototypeTop.MovesToFloor.Contains(player.Floor + 1))
                            {
                                player.Floor++;
                                if (roomPrototypeTop.MovesToRoom != null)
                                {
                                    var newRoom = lobby.Rooms.Where(room => room.RoomProtoype == roomPrototypeTop.MovesToRoom && room.Floor == player.Floor).FirstOrDefault();
                                    player.X = newRoom.X;
                                    player.Y = newRoom.Y;
                                }
                            }

                            if (roomPrototypeTop.MovesToPositionX != null && roomPrototypeTop.MovesToPositionY != null)
                            {
                                player.Floor++;
                                player.X = roomPrototypeTop.MovesToPositionX.Value;
                                player.Y = roomPrototypeTop.MovesToPositionY.Value;
                            }

                        }
                        break;
                }

                await Clients.Group(action.lobbyCode).MoveCharacterToPosition(new MovementRequest
                {
                    Character = player.CharacterPrototypeId,
                    Floor = player.Floor,
                    X = player.X,
                    Y = player.Y
                });

                player.AvailableMoves--;
                if(player.AvailableMoves <= 0)
                {
                    var user = await userManager.FindByEmailAsync(Context.User?.FindFirst(ClaimTypes.Email)?.Value);

                    await Clients.User(user.Id).EndTurn();

                    var turnNo = player.TurnIndex;
                    if(player.TurnIndex == lobby.Players.Count - 1)
                    {
                        lobby.CurrentPlayerId = lobby.Players.Find(p => p.TurnIndex == 0).Id;
                    } else
                    {
                        lobby.CurrentPlayerId = lobby.Players.Where(p => p.TurnIndex > turnNo).OrderBy(x => x.TurnIndex).First().Id;
                    }
                    var newTurnUser = await userManager.FindByEmailAsync(Context.User?.FindFirst(ClaimTypes.Email)?.Value);
                    await Clients.User(newTurnUser.Id).StartTurn(new ClientRequestModels.TurnRequest
                    {
                        CanThrowDiceForMovement = true
                    });
                    gameContext.ThrowRequests.Add(new ThrowRequest
                    {
                        Player = lobby.Players.Find(x => x.Id == lobby.CurrentPlayerId),
                        Motive = ThrowMotive.MOVEMENT,
                        Dice = DiceThrow.ThrowTypes.OneSixFaceDice,
                    });
                }

                await gameContext.SaveChangesAsync();
                return new MovementResult
                {
                    Floor = player.Floor,
                    X = player.X,
                    Y = player.Y
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

        public async Task<PuzzleResult> CheckPuzzle(PuzzleActions req)
        {
            var lobby = gameContext.Lobbies.Find(req.lobbyCode);
            var puzzle = gameContext.Puzzles.Find(req.PuzzleId);

            var puzzlePrototype = Puzzles.puzzles.Find(x => x.id == puzzle.PuzzlePrototype);

            if (lobby.CurrentPlayerId == req.playerToken && puzzle.PlayersId == req.playerToken)
            {
                var requestPayload = new PuzzleCheckRequest(req.Code, puzzlePrototype.expectedOutput,
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
                    var affectedPlayer = gameContext.Players.Where(x => x.LobbyId == req.lobbyCode && x.CharacterPrototypeId == req.AffectsCharacter).First();
                    if (affectedPlayer == null)
                    {
                        throw new HubException("Player not found on lobby");
                    }

                    if (puzzle.ModifiesStats)
                    {
                        affectedPlayer.Physical += puzzle.PhysicalStatDiff;
                        affectedPlayer.Intelligence += puzzle.IntelligenceStatDiff;
                        affectedPlayer.Sanity += puzzle.SanityStatDiff;
                        affectedPlayer.Bravery += puzzle.BraveryStatDiff;

                        await Clients.Group(req.lobbyCode).ChangeStats(new ClientRequestModels.ChangeStats { 
                            PlayerName = affectedPlayer.CharacterPrototypeId,
                            Stats = new LaCasaDelTerror.Assets.Abstracts.Stats
                            {
                                Physical = affectedPlayer.Physical,
                                Intelligence = affectedPlayer.Intelligence,
                                Sanity = affectedPlayer.Sanity,
                                Bravery = affectedPlayer.Bravery
                            }
                        });
                    }

                    if (puzzle.ModifiesPosition)
                    {
                        if(puzzle.NewX != -1)
                        {
                            affectedPlayer.X = puzzle.NewX;
                        }

                        if (puzzle.NewY != -1)
                        {
                            affectedPlayer.Y = puzzle.NewY;
                        }

                        if (puzzle.NewFloor != -1)
                        {
                            affectedPlayer.Floor = puzzle.NewFloor;
                        }

                        await Clients.Group(req.lobbyCode).MoveCharacterToPosition(new MovementRequest
                        {
                            X = affectedPlayer.X,
                            Y = affectedPlayer.Y,
                            Floor = affectedPlayer.Floor,
                            Character = affectedPlayer.CharacterPrototypeId
                        });
                    }
                }

                return new PuzzleResult
                {
                    Correct = correct,
                    Output = output
                };
            }

            await gameContext.SaveChangesAsync();

            return new PuzzleResult { Correct = false, Output = "" };
        }

        public async Task<bool> EnterLobby(string code)
        {
            if (gameContext.Lobbies.Find(code) != null)
            {
                await Clients.Group(code).PlayerJoinedLobby();
                await Groups.AddToGroupAsync(Context.ConnectionId, code);

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

        public async Task<PlayerSelectionResult> SelectCharacter(SelectCharacterAction action)
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
                User = await userManager.FindByEmailAsync(Context.User?.FindFirst(ClaimTypes.Email)?.Value),
                Name = action.Name,
                CharacterPrototypeId = action.Character
            };

            gameContext.Add(newPlayer);

            gameContext.SaveChanges();

            var response = new PlayerSelectionResult
            {
                PlayerToken = newPlayer.Id.ToString()
            };

            return response;
        }
        
        public Task<ThrowResult> ThrowDice(ClientRequestModels.ThrowRequest throwRequest)
        {
            var player = gameContext.Players.Find(throwRequest.PlayerToken);
            var latestThrowRequest = gameContext.ThrowRequests.Where(x => x.Player.Id.ToString() == throwRequest.PlayerToken).OrderByDescending(x => x.TimeOfRequest).FirstOrDefault();

            if (player != null && latestThrowRequest != null)
            {
                var diceThrowRes = diceThrow.DoThrow(latestThrowRequest.Dice);
                if(latestThrowRequest.Motive == ThrowMotive.MOVEMENT)
                {
                    player.AvailableMoves = diceThrowRes;
                }

                return Task.FromResult(new ThrowResult
                {
                    DiceThrow = diceThrowRes
                });
                
            }

            return null;
        }
    }
}
