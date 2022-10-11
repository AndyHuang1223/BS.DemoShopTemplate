using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Admin.BaseModels;
using BS.DemoShop.Admin.Helpers;
using BS.DemoShop.Admin.WebApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Admin.WebApi
{
    [Authorize]
    public class AuthController : BaseApiController
    {
        private readonly JwtHelper _jwt;

        public AuthController(JwtHelper jwt)
        {
            _jwt = jwt;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(LoginInDTO request)
        {
            if (IsUserValid(request)) {
                return Ok(new BaseApiResponse(_jwt.GenerateToken(request.UserName)));
            }

            return Ok(new BaseApiResponse() { IsSuccess = false, Code = Enums.ApiStatusEnum.NotFound });
        }

        [HttpGet]
        [Authorize(Roles="Admin")]
        public IActionResult GetUserName()
        {
            return Ok(new BaseApiResponse(User.Identity.Name));
        }

        [HttpGet]
        [Authorize(Roles="SuperAdmin")]
        public IActionResult GetClaims()
        {
            return Ok(new BaseApiResponse(User.Claims.Select(x => new { x.Type, x.Value })));
        }

        private bool IsUserValid(LoginInDTO request)
        {
            return true;
        }
    }

    public class LoginInDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}