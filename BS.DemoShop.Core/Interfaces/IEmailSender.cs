using System.Threading.Tasks;

namespace BS.DemoShop.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string recipientEmail, string recipientName,  string subject, string htmlBody);
    }
}