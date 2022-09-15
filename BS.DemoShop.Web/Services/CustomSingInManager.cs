using BS.DemoShop.Core.Entities;
using BS.DemoShop.Core.Extensions;
using BS.DemoShop.Core.Interfaces;
using BS.DemoShop.Web.Interfaces;
using BS.DemoShop.Web.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Services
{
    public class CustomSingInManager : ISingInManager
    {
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Role> _roleRepo;
        private readonly IRepository<UserRole> _userRoleRepo;
        private readonly HttpContext _httpContext;
        private readonly IAppPasswordHasher _appPasswordHasher;

        public CustomSingInManager(IRepository<User> userRepo,
            IHttpContextAccessor httpContextAccessor,
            IRepository<Role> roleRepo,
            IRepository<UserRole> userRoleRepo,
            IAppPasswordHasher appPasswordHasher)
        {
            _userRepo = userRepo;
            _httpContext = httpContextAccessor.HttpContext;
            _roleRepo = roleRepo;
            _userRoleRepo = userRoleRepo;
            _appPasswordHasher = appPasswordHasher;
        }
        public bool IsExistUser(User user)
        {
            return _userRepo.Any(u => u.Email == user.Email);
        }

        public bool CanUserSignIn(User user)
        {
            return _userRepo.Any(u => u.Email == user.Email && u.Password == _appPasswordHasher.HashPassword(user.Password));
        }

        public async Task SignInAsync(User user, bool isPersistent = true)
        {
            
            var claimsIdentity = BuildClaimsIdentity(user);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
            {
                //TODO 調整為合適的過期時間
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = isPersistent
            });
        }

        public bool IsAuthenticated()
        {
            return _httpContext.User.Identity != null && _httpContext.User.Identity.IsAuthenticated;
        }
        public async Task SignOutAsync()
        {
            await _httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task SignUpAsync(SignUpViewModel input)
        {
            var user = new User
            {
                Email = input.Email,
                Name = input.Name,
                Gender = input.Gender,
                CreatedTime = DateTimeOffset.UtcNow,
                Password = _appPasswordHasher.HashPassword(input.Password)
            };
            
            var normalRole = await _roleRepo.FirstOrDefaultAsync(x => x.RoleType == RoleType.NormalUser);
            var userRole = await _userRoleRepo.AddAsync(new UserRole { Role = normalRole, User = user });
            
            await SignInAsync(userRole.User);
        }

        public async Task<User> GetUser(User user)
        {
            return await _userRepo.SingleOrDefaultAsync(u => u.Email == user.Email && u.Password == _appPasswordHasher.HashPassword(user.Password));
        }

        private static ClaimsIdentity SetClaimsIdentity(string userName, IEnumerable<Role> roles)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(ClaimTypes.Name, userName));

            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.Name));
            }

            return identity;
        }

        private ClaimsIdentity BuildClaimsIdentity(User user)
        {
            var userRoles = _userRoleRepo.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            var roles = _roleRepo.Where(r => userRoles.Contains(r.Id)).ToList();
            var userIdentity = SetClaimsIdentity(user.Name ?? user.Email, roles);
            return userIdentity;
        }
    }
}