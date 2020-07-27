using LaCasaDelTerror.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectHamiltonService.Models;

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


        [HttpPost]
        public IActionResult RegisterLobby()
        {
            var newLobby = new Lobbies();

            gameContext.Lobbies.Add(newLobby);

            var result = new CreatedLobbyInfo
            {
                code = newLobby.Code
            };

            return new JsonResult(result);
        }
    }
}
