using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Admin.Controllers
{
    public class ErrorPages : Controller
    {
        public IActionResult Error401()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }
    }
}
