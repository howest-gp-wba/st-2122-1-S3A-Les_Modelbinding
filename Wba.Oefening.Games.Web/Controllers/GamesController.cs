using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Domain;

namespace Wba.Oefening.Games.Web.Controllers
{

    public class GamesController : Controller
    {
        private readonly GameRepository gameRepository;

        public GamesController()
        {
            gameRepository = new GameRepository();
        }

        [Route("games")]
        [Route("games/index")]
        [Route("games/all")]

        public IActionResult Index()
        {
            //get data
            var games = gameRepository.GetGames();

            //format data
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.AppendLine("<h2>Games page</h2>");
            outputBuilder.AppendLine(FormatGameInfo(games));

            //simple output via Content() instead of View()
            return Content(outputBuilder.ToString(), "text/html");
        }

        [Route("games/{id}")]
        public IActionResult ShowGame(int id)
        {
            //get data (with a Linq Extension method)
            var developer = gameRepository.GetGames()
                .FirstOrDefault(d => d.Id == id);

            //format data
            var output = FormatGameInfo(developer);

            //simple output via Content() instead of View()
            return Content(output, "text/html");
        }

        private string FormatGameInfo(Game game)
        {
            StringBuilder gameInfo = new StringBuilder();
            gameInfo.Append("<h3>Game Info</h3><ul>");
            gameInfo.Append($"<li>Game Id: {game?.Id}</li>");
            gameInfo.Append($"<li>Title: {game?.Title}</li>");
            gameInfo.Append($"<li>Developer: {game?.Developer.Name}</li>");
            gameInfo.Append($"<li>Rating: {game?.Rating}</li></ul>");
            
            return gameInfo.ToString();
        }

        private string FormatGameInfo(IEnumerable<Game> games)
        {
            StringBuilder gamesInfo = new StringBuilder();
            foreach (var game in games)
            {
                gamesInfo.Append(FormatGameInfo(game));
            }

            return gamesInfo.ToString();
        }
    }
}