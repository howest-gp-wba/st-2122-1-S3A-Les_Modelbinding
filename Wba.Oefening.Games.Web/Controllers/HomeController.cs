using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.Games.Web.Models;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("home")]
        [Route("home/index")]
        public IActionResult Index()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<h2>Rate-a-game!</h2>");
            stringBuilder.Append("<table>");
            stringBuilder.Append("<tr>");
            stringBuilder.Append("<td><a href=\"games/index\">List of Games</a></td>");
            stringBuilder.Append("</tr>");
            stringBuilder.Append("<tr>");
            stringBuilder.Append("<td><a href=\"developers/index\">List of Developers</a></td>");
            stringBuilder.Append("</tr>");
            stringBuilder.Append("</table>");
            return Content(stringBuilder.ToString(), "text/html");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
