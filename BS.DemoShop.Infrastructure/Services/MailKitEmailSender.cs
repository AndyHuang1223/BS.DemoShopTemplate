using BS.DemoShop.Core.Interfaces;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.DemoShop.Infrastructure.Services
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly string _account;
        private readonly string _password;
        private readonly ILogger<MailKitEmailSender> _logger;
        public MailKitEmailSender(IConfiguration configuration, ILogger<MailKitEmailSender> logger)
        {
            _account = configuration.GetSection("MailKitSettings:Account").Value;
            _password = configuration.GetSection("MailKitSettings:Password").Value;
            _logger = logger;
        }
        public Task SendEmailAsync(string recipientEmail, string recipientName, string subject, string htmlBody)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("BS-TA", "andyhuang@build-school.com"));
                emailMessage.To.Add(new MailboxAddress(recipientName, recipientEmail));
                emailMessage.Subject = subject;
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = htmlBody;
                emailMessage.Body = bodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(_account, _password);

                    client.Send(emailMessage);
                    client.Disconnect(true);
                }
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            

            return Task.CompletedTask;
        }
    }
}
