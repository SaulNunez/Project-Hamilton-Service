﻿using LaCasaDelTerror.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectHamiltonService.Models;
using System;
using System.Linq;
using System.Net.Mime;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectHamiltonService.Controllers
{
    public class TeacherController : Controller
    {
        private GameContext gameContext;

        public TeacherController(GameContext gameContext)
        {
            this.gameContext = gameContext;
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
            var lobby = gameContext.Lobbies.Where(x => x.code == gameStart.lobbyCode).First();

            if (lobby == null)
            {
                return new NotFoundResult();
            }

            if (gameContext.Players.Where(x => x.lobbyId == gameStart.lobbyCode).Count() < 2)
            {
                return new StatusCodeResult(403);
            }

            lobby.onProgress = true;

            await gameContext.SaveChangesAsync();

            return new OkResult();
        }


        [HttpPost]
        [Route("Teacher/CreateLobby")]
        public async System.Threading.Tasks.Task<IActionResult> CreateLobbyAsync()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var code = new string(Enumerable.Repeat(chars, 5)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            gameContext.Add(new Models.Lobbies { code = code });

            await gameContext.SaveChangesAsync();

            return new OkObjectResult(new { code });
        }
    }
}
