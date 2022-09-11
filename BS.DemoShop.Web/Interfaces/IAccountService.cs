using BS.DemoShop.Web.ViewModels.Account;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.Interfaces
{
    public interface IAccountService
    {
        bool IsExistUser(string email);

        bool CanUserSignIn(string email, string password);

        Task<ClaimsIdentity> GetUserClaimsIdentity(string email, string password);

        Task SignInAsync(ClaimsIdentity claimsIdentity, bool isPersistent = true);

        Task SignOutAsync();

        bool IsAuthenticated();

        Task SignUpAsync(SignUpViewModel input);

    }
}
