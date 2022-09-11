using BS.DemoShop.Core.Constants;
using BS.DemoShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BS.DemoShop.Controllers
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
        [Authorize(Roles = "Administrator, Developer")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = AuthorizationConstants.Administrator)]
        public IActionResult Admin()
        {
            return View("Index");
        }
        [Authorize(Roles = AuthorizationConstants.Developer)]
        public IActionResult Developer()
        {
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
