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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppPasswordHasher _appPasswordHasher;
        public CustomSingInManager(IRepository<User> userRepo,
            IHttpContextAccessor httpContextAccessor,
            IRepository<Role> roleRepo,
            IRepository<UserRole> userRoleRepo,
            IAppPasswordHasher appPasswordHasher)
        {
            _userRepo = userRepo;
            _httpContextAccessor = httpContextAccessor;
            _roleRepo = roleRepo;
            _userRoleRepo = userRoleRepo;
            _appPasswordHasher = appPasswordHasher;
        }

        public bool CanUserSignIn(string email, string password)
        {
            return _userRepo.GetAllReadOnly().Any(user => user.Email == email && user.Password == _appPasswordHasher.HashPassword(password));
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsExistUser(string email)
        {
            return _userRepo.GetAllReadOnly().Any(user => user.Email == email);
        }

        public async Task SignInAsync(ClaimsIdentity claimsIdentity, bool isPersistent = true)
        {

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await _httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
            {
                //TODO 調整為合適的過期時間
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = isPersistent
            });

        }

        public async Task SignOutAsync()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task SignUpAsync(SignUpViewModel input)
        {
            var user = new User
            {
                Email = input.Email,
                Name = input.Name,
                Gender = input.Gender.Value,
                CreatedTime = DateTimeOffset.UtcNow,
                Password = _appPasswordHasher.HashPassword(input.Password)
            };
            var result = _userRepo.Add(user);
            var userIdentity = BuildClaimsIdentity(result);
            await SignInAsync(userIdentity);
        }

        
        public async Task<ClaimsIdentity> GetUserClaimsIdentity(string email, string password)
        {
            var user = _userRepo.GetAllReadOnly().SingleOrDefault(user => user.Email == email && user.Password == _appPasswordHasher.HashPassword(password));
            if (user == null)
            {
                //TODO User Notfount Exception
                await SignOutAsync();
                return default;
            }

            var claimsIdentity = BuildClaimsIdentity(user);

            return claimsIdentity;
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
            var userRoles = _userRoleRepo.GetAllReadOnly().Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            var roles = _roleRepo.GetAllReadOnly().Where(r => userRoles.Contains(r.Id)).ToList();
            var userIdentity = SetClaimsIdentity(user.Name ?? user.Email, roles);
            return userIdentity;
        }

    }
}
