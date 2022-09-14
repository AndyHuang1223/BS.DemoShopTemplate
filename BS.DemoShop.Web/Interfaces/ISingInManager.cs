using BS.DemoShop.Web.ViewModels.Account;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BS.DemoShop.Core.Entities;

namespace BS.DemoShop.Web.Interfaces
{
    public interface ISingInManager
    {
        bool IsExistUser(User user);

        bool CanUserSignIn(User user);

        // Task<ClaimsIdentity> GetUserClaimsIdentity(string email, string password);

        Task SignInAsync(User user, bool isPersistent = true);

        Task SignOutAsync();

        bool IsAuthenticated();

        Task SignUpAsync(SignUpViewModel input);

        Task<User> GetUser(User user);

    }
}
