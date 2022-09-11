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
        private readonly IAccountService _accountService;
        private readonly IAccountViewModelService _accountViewModelService;

        public AccountController(IAccountService accountService, IAccountViewModelService accountViewModelService)
        {
            _accountService = accountService;
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


            if (!_accountService.CanUserSignIn(input.Email, input.Password))
            {
                TempData["Error"] = "帳號或密碼錯誤";
                return View(input);
            }

            var userClaims = await _accountService.GetUserClaimsIdentity(input.Email, input.Password);
            if(userClaims == null)
            {
                TempData["Error"] = "系統異常，請重新再試一遍，若持續發生請洽客服人員！";
                return View(input);
            }
            await _accountService.SignInAsync(userClaims);

            string returnUrl = string.IsNullOrEmpty(input.ReturnUrl) ? "/" : input.ReturnUrl;

            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            await _accountService.SignOutAsync();

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

            if (_accountService.IsExistUser(input.Email))
            {
                TempData["Error"] = "此帳號已被使用。";
                input.GenderList = _accountViewModelService.GetUserGenderItems(input.Gender).ToList();
                return View(input);
            }

            await _accountService.SignUpAsync(input);

            var returnUrl = string.IsNullOrEmpty(input.ReturnUrl) ? "/" : input.ReturnUrl;

            return Redirect(returnUrl);

        }
    }
}
