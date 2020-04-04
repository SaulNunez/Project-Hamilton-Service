using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectHamiltonService.Controllers
{
    public class GameController : Controller
    {
        [HttpPost]
        public IActionResult Index(string lobbyCode)
        {
            return Ok();
        }
    }
}