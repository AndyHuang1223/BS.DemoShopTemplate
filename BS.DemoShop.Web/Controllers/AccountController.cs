using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Web.Controllers
{
    public class AccountController : Controller
    {
        [Route("/signin")]
        public IActionResult SignIn(string returnUrl)
        {
            return View();
        }
    }
}
