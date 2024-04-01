using DemoShop.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoShop.Admin.Controllers
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
        
        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Echarts()
        {
            return View();
        }
        
        public IActionResult Table()
        {
            return View();
        }

        public IActionResult TodoList()
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