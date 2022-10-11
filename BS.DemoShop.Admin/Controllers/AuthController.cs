using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Admin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }
    }
}