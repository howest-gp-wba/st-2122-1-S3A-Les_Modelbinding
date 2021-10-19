using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.Games.Core;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class BindingController : Controller
    {
        private FormattingService formattingService;

        public BindingController()
        {
            formattingService = new FormattingService();
        }

        public IActionResult Index()
        {
            return Content("Index", "text/html");
        }

        [HttpPost]
        public IActionResult GetGame(
            [FromQuery] int gameId, 
            [FromForm] string gameTitle,
            [FromForm] string gameDeveloper,
            [FromForm] int gameRating)
        {
            Game game = new Game
            {
                Id = gameId,
                Title = gameTitle,
                Developer = new Developer { Name = gameDeveloper },
                Rating = gameRating
            };

            return Content(formattingService.FormatGameInfo(game));

        }
    }
}
