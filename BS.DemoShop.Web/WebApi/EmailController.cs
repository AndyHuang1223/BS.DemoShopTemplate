using BS.DemoShop.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BS.DemoShop.Web.WebApi
{
    public class EmailController : BaseApiController
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailRequest request)
        {
            await _emailSender.SendEmailAsync(request.RecipientEmail, request.RecipientName, request.Subject, request.Body);
            return Ok();
        }
    }
    public class SendEmailRequest
    {
        public string RecipientEmail { get; set; }
        public string RecipientName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
