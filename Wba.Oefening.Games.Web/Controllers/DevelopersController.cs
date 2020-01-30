using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Domain;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository developerRepository;
        private readonly FormattingService formattingService;

        public DevelopersController()
        {
            //initialize service classes
            developerRepository = new DeveloperRepository();
            formattingService = new FormattingService();
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
            outputBuilder.AppendLine(formattingService.FormatDeveloperInfo(developers));

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
            var output = formattingService.FormatDeveloperInfo(developer);

            //simple output via Content() instead of View()
            return Content(output, "text/html");
        }

    }
}