using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Core;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{

    public class GamesController : Controller
    {
        private readonly GameRepository gameRepository;
        private readonly FormattingService formattingService;

        public GamesController()
        {
            gameRepository = new GameRepository();
            formattingService = new FormattingService();
        }

        public IActionResult Index()
        {
            //get data
            var games = gameRepository.GetGames();

            //format data
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.AppendLine("<h2>Games page</h2>");
            outputBuilder.AppendLine(formattingService.FormatGameInfo(games));

            //simple output via Content() instead of View()
            return Content(outputBuilder.ToString(), "text/html");
        }

        public IActionResult ShowGame(int id)
        {
            //get data (with a Linq Extension method)
            var developer = gameRepository.GetGames()
                .FirstOrDefault(d => d.Id == id);

            //format data
            var output = formattingService.FormatGameInfo(developer);

            //simple output via Content() instead of View()
            return Content(output, "text/html");
        }

    }
}