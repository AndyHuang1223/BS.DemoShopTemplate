using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Charts()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }

    }
}
