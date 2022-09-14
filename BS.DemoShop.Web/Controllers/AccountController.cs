using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISingInManager _signInManager;
        private readonly IAccountViewModelService _accountViewModelService;

        public AccountController(ISingInManager signInManager, IAccountViewModelService accountViewModelService)
        {
            _signInManager = signInManager;
            _accountViewModelService = accountViewModelService;
        }

        [Route("/signin")]
        public IActionResult SignIn(string returnUrl)
        {
            var model = new SignInViewModel() { ReturnUrl = returnUrl };
            return View(model);
        }

        [Route("/signin")]
        [HttpPost]
        [ValidateAntiForgeryToken] //跨站防偽 https://docs.microsoft.com/zh-tw/aspnet/core/security/anti-request-forgery?view=aspnetcore-5.0
        public async Task<IActionResult> SignIn(SignInViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            var user = new User
            {
                Email = input.Email,
                Password = input.Password,
            };

            if (!_signInManager.CanUserSignIn(user))
            {
                TempData["Error"] = "帳號或密碼錯誤";
                return View(input);
            }

            var sourceUser = await _signInManager.GetUser(user);

            if (sourceUser is null)
            {
                //TODO 查無會員資料處理
                TempData["Error"] = "系統錯誤，請稍後再試！";
                return View(input);   
            }
            
            await _signInManager.SignInAsync(sourceUser, input.IsRemember);

            var returnUrl = string.IsNullOrEmpty(input.ReturnUrl) ? "/" : input.ReturnUrl;

            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _signInManager.SignOutAsync();

            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;

            return Redirect(returnUrl);
        }

        public IActionResult SignUp(string returnUrl)
        {
            var model = new SignUpViewModel() { ReturnUrl = returnUrl, GenderList = _accountViewModelService.GetUserGenderItems().ToList() };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpViewModel input)
        {
            if (!ModelState.IsValid)
            {
                input.GenderList = _accountViewModelService.GetUserGenderItems(input.Gender).ToList();
                return View(input);
            }

            if(input.Password != input.ConfirmPassword)
            {
                TempData["Error"] = "請確認密碼。";
                input.GenderList = _accountViewModelService.GetUserGenderItems(input.Gender).ToList();
                return View(input);
            }

            var user = new User
            {
                Name = input.Name,
                Email = input.Email,
                Password = input.Password
            };

            if (_signInManager.IsExistUser(user))
            {
                TempData["Error"] = "此帳號已被使用。";
                input.GenderList = _accountViewModelService.GetUserGenderItems(input.Gender).ToList();
                return View(input);
            }

            await _signInManager.SignUpAsync(input);

            var returnUrl = string.IsNullOrEmpty(input.ReturnUrl) ? "/" : input.ReturnUrl;

            return Redirect(returnUrl);

        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
