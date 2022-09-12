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

        public bool CanUserSignIn(string email, string password)
        {
            return _userRepo.Any(user => user.Email == email && user.Password == _appPasswordHasher.HashPassword(password));
        }

        public bool IsAuthenticated()
        {
            return _httpContext.User.Identity != null && _httpContext.User.Identity.IsAuthenticated;
        }

        public bool IsExistUser(string email)
        {
            return _userRepo.Any(user => user.Email == email);
        }

        public async Task SignInAsync(ClaimsIdentity claimsIdentity, bool isPersistent = true)
        {
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            await _httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties
            {
                //TODO 調整為合適的過期時間
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = isPersistent
            });
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
                Gender = input.Gender ?? UserGender.None,
                CreatedTime = DateTimeOffset.UtcNow,
                Password = _appPasswordHasher.HashPassword(input.Password)
            };
            
            var normalRole = await _roleRepo.FirstOrDefaultAsync(x => x.RoleType == RoleType.NormalUser);
            await _userRoleRepo.AddAsync(new UserRole { Role = normalRole, User = user });
            
            var userIdentity = BuildClaimsIdentity(user);
            
            await SignInAsync(userIdentity);
        }


        public async Task<ClaimsIdentity> GetUserClaimsIdentity(string email, string password)
        {
            var user = await _userRepo.SingleOrDefaultAsync(user => user.Email == email && user.Password == _appPasswordHasher.HashPassword(password));
            if (user == null)
            {
                //TODO User not found Exception
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
            var userRoles = _userRoleRepo.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToList();
            var roles = _roleRepo.Where(r => userRoles.Contains(r.Id)).ToList();
            var userIdentity = SetClaimsIdentity(user.Name ?? user.Email, roles);
            return userIdentity;
        }
    }
}