using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}