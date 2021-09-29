using System.Collections.Generic;
using System.Text;
using Wba.Oefening.Games.Core;

namespace Wba.Oefening.Games.Web.Services
{
    public class FormattingService
    {

        public string FormatGameInfo(Game game)
        {
            StringBuilder gameInfo = new StringBuilder();
            gameInfo.Append("<h3>Game Info</h3><ul>");
            gameInfo.Append($"<li>Game Id: {game?.Id}</li>");
            gameInfo.Append($"<li>Title: <a href=\"/games/{game?.Id}\">{game?.Title}</a></li>");
            gameInfo.Append($"<li>Developer: <a href=\"/developers/{game?.Developer?.Id}\">{game?.Developer?.Name}</a></li>");
            gameInfo.Append($"<li>Rating: {game?.Rating}</li></ul>");

            return gameInfo.ToString();
        }

        public string FormatGameInfo(IEnumerable<Game> games)
        {
            StringBuilder gamesInfo = new StringBuilder();
            foreach (var game in games)
            {
                gamesInfo.Append(FormatGameInfo(game));
            }

            return gamesInfo.ToString();
        }

        public string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder developerInfo = new StringBuilder();
            developerInfo.AppendLine("<h3>Developer Info</h3><ul>");
            developerInfo.AppendLine($"<li>Dev Id: {developer?.Id}</li>");
            developerInfo.AppendLine($"<li>Name: <a href=\"/developers/{developer?.Id}\">{developer?.Name}</a></li></ul>");
            
            return developerInfo.ToString();
        }

        public string FormatDeveloperInfo(IEnumerable<Developer> developers)
        {
            StringBuilder developersInfo = new StringBuilder();
            foreach (var developer in developers)
            {
                developersInfo.Append(FormatDeveloperInfo(developer));
            }

            return developersInfo.ToString();
        }
    }
}
