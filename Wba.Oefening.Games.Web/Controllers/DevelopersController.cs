using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Domain;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository developerRepository;

        public DevelopersController()
        {
            //initialize service classes
            developerRepository = new DeveloperRepository();
        }

        [Route("developers")]
        [Route("developers/index")]
        [Route("developers/all")]
        public IActionResult Index()
        {
            //get data
            var developers = developerRepository.GetDevelopers();
            
            //format data
            StringBuilder outputBuilder = new StringBuilder();
            outputBuilder.AppendLine("<h2>Developers page</h2>");
            outputBuilder.AppendLine(FormatDeveloperInfo(developers));

            //simple output via Content() instead of View()
            return Content(outputBuilder.ToString(), "text/html");
        }

        [Route("developers/{id}")]
        public IActionResult ShowDeveloper(int id)
        {
            //get data (with a Linq Extension method)
            var developer = developerRepository.GetDevelopers()
                .FirstOrDefault(d => d.Id == id);

            //format data
            var output = FormatDeveloperInfo(developer);

            //simple output via Content() instead of View()
            return Content(output, "text/html");
        }

        private string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder developerInfo = new StringBuilder();
            developerInfo.AppendLine("<h3>Developer Info</h3><ul>");
            developerInfo.AppendLine($"<li>Dev Id: {developer?.Id}</li>");
            developerInfo.AppendLine($"<li>Name: {developer?.Name}</li></ul>");
            return developerInfo.ToString();
        }

        private string FormatDeveloperInfo(IEnumerable<Developer> developers)
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