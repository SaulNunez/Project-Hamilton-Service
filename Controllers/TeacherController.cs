using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ProjectHamiltonService.Game;
using ProjectHamiltonService.Models;
using System;
using System.Linq;
using System.Net.Mime;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectHamiltonService.Controllers
{
    public class TeacherController : Controller
    {
        private readonly GameContext gameContext;
        private readonly IHubContext<ServerHub> hubContext;

        public TeacherController(GameContext gameContext, IHubContext<ServerHub> hubContext)
        {
            this.gameContext = gameContext;
            this.hubContext = hubContext;
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

            if (gameContext.Players.Where(x => x.LobbyId == gameStart.lobbyCode).Count() < 2)
            {
                return new StatusCodeResult(403);
            }

            lobby.OnProgress = true;

            await gameContext.SaveChangesAsync();

            await hubContext.Clients.Group(gameStart.lobbyCode).SendAsync("SessionStart");

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
