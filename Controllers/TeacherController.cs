using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game;
using ProjectHamiltonService.Game.ClientRequestModels;
using ProjectHamiltonService.Game.utils;
using ProjectHamiltonService.Models;
using System;
using System.Linq;
using System.Net.Mime;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectHamiltonService.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly GameContext gameContext;
        private readonly IHubContext<ServerHub, IClientActions> hubContext;
        private readonly DiceThrow diceThrow;

        public TeacherController(GameContext gameContext, IHubContext<ServerHub, IClientActions> hubContext, DiceThrow diceThrow)
        {
            this.gameContext = gameContext;
            this.hubContext = hubContext;
            this.diceThrow = diceThrow;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        private static Random random = new Random();

        public class GameStart
        {
            public string lobbyCode;
        }

        [HttpPost]
        [Route("Teacher/StartGame")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async System.Threading.Tasks.Task<IActionResult> StartGameSessionAsync(GameStart gameStart)
        {
            var lobby = gameContext.Lobbies.Where(x => x.Code == gameStart.lobbyCode).First();

            if (lobby == null)
            {
                return new NotFoundResult();
            }

            var players = gameContext.Players.Where(x => x.LobbyId == gameStart.lobbyCode);

            if (players.Count() < 2)
            {
                return new StatusCodeResult(403);
            }

            lobby.OnProgress = true;


            //Aparte de calcular el tiro de los jugadores, calculamos cual es su orden
            foreach(var player in players)
            {
                player.TurnThrowResult = diceThrow.DoThrow(DiceThrow.ThrowTypes.OneSixFaceDice);
            }

            var ordered = players.OrderBy(x => x.TurnThrowResult);

            foreach(var (player, index) in ordered.WithIndex())
            {
                player.TurnIndex = index;
            }

            await hubContext.Clients.Group(gameStart.lobbyCode).StartGame(new PlayerOrderInformation { 
                    PlayerOrder = ordered.Select(x => new CharacterOrder { 
                        CharacterName = x.CharacterPrototypeId,
                        TurnOrder = x.TurnIndex,
                        TurnThrow = x.TurnThrowResult
                    }).ToList()
                });

            await gameContext.SaveChangesAsync();

            return new OkResult();
        }

        [HttpPost]
        [Route("Teacher/CreateLobby")]
        public async System.Threading.Tasks.Task<IActionResult> CreateLobbyAsync([FromServices] MansionCreation mansionCreation)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var code = new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            gameContext.Add(new Lobbies { Code = code });

            await gameContext.SaveChangesAsync();

            await mansionCreation.populateFloorAsync(code, LaCasaDelTerror.Assets.Rooms.basement, -1);
            await mansionCreation.populateFloorAsync(code, LaCasaDelTerror.Assets.Rooms.mainFloor, 0);
            await mansionCreation.populateFloorAsync(code, LaCasaDelTerror.Assets.Rooms.topFloor, 1);

            return new OkObjectResult(new { code });
        }
    }
}
