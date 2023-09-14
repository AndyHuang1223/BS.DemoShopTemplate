using System;
using System.Threading.Tasks;
using BS.DemoShop.Core.Interfaces;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.Extensions.Configuration;

namespace BS.DemoShop.Infrastructure.Services
{
    public class SendGridEmailSender : IEmailSender
    {
        private readonly string _apiKey;
        public SendGridEmailSender(IConfiguration configuration)
        {
            _apiKey = configuration.GetSection("SendGridSettings:ApiKey").Value;
        }

        public async Task SendEmailAsync(string recipientEmail, string recipientName, string subject, string htmlBody)
        {
            var apiKey = _apiKey;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("andyhuang@build-school.com", "BS TA");
            
            var to = new EmailAddress(recipientEmail, recipientName);
            var plainTextContent = $"and easy to do anywhere, even with C# {htmlBody}";
            var htmlContent = $"<strong>{plainTextContent}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}