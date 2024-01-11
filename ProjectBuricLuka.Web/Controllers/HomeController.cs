using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ProjectBuricLuka.Web.Models;

namespace ProjectBuricLuka.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Route("cesta-pitanja/{selected:int:min(1):max(9)?}")]
        public IActionResult FAQ(int? selected = null)
        {
            ViewData["selected"] = selected;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}