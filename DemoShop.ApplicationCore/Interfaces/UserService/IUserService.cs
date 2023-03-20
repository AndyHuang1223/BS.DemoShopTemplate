using System.Runtime.InteropServices;
using DemoShop.ApplicationCore.Entities;

namespace DemoShop.ApplicationCore.Interfaces.UserService;

public interface IUserService
{
    Task<Member> GetValidUserByIdAsync(int memberId);
}