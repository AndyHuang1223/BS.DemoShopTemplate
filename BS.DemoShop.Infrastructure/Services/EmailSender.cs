using System.Threading.Tasks;
using BS.DemoShop.Core.Interfaces;

namespace BS.DemoShop.Infrastructure.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //TODO 需要加入Email相關服務(SendGrid or EmailServer)
            return Task.CompletedTask;
        }
    }
}