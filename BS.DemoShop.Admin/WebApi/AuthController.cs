using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BS.DemoShop.Admin.BaseModels;
using BS.DemoShop.Admin.Helpers;
using BS.DemoShop.Admin.WebApi;
using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BS.DemoShop.Admin.WebApi
{
    public class AuthController : BaseApiController
    {
        private readonly JwtHelper _jwt;
        private readonly IRepository<BlockToken> _blockTokenRepo;

        public AuthController(JwtHelper jwt, IRepository<BlockToken> blockTokenRepo)
        {
            _jwt = jwt;
            _blockTokenRepo = blockTokenRepo;
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

        [HttpPost]
        public IActionResult Logout([FromBody]LogoutDTO request)
        {
            _blockTokenRepo.Add(new BlockToken
            {
                Token = request.Token,
                ExpireTime = DateTimeOffset.UtcNow.ToUniversalTime()
            });
            return Ok();
        }
    }

    public class LoginInDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LogoutDTO
    {
        public string Token { get; set; }
    }
}