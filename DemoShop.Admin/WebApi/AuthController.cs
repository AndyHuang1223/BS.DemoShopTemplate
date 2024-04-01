using System.Runtime.CompilerServices;
using DemoShop.Admin.Helpers;
using DemoShop.Admin.Models;
using DemoShop.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoShop.Admin.WebApi;

[ApiController]
[Route("/api/[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly JwtHelper _jwt;
    private readonly UserMangerService _userMangerService;

    public AuthController(JwtHelper jwt, UserMangerService userMangerService)
    {
        _jwt = jwt;
        _userMangerService = userMangerService;
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Login(LoginInDTO request)
    {
        if (!_userMangerService.IsUserValid(request))
        {
            return Ok(new BaseApiResponse());
        }

        return Ok(new BaseApiResponse(_jwt.GenerateToken(request.UserName,1)));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUserName()
    {
        return Ok(new BaseApiResponse(_userMangerService.GetUserName()));
    }

    [HttpGet]
    // [Authorize(Roles = "SuperAdmin")]
    public IActionResult GetClaims()
    {
        return Ok(new BaseApiResponse(User.Claims.Select(x => new { x.Type, x.Value })));
    }

    
}

public class LoginInDTO
{
    public string UserName { get; set; }
    public string Password { get; set; }
}