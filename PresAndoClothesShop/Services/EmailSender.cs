using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;

namespace PresAndoClothesShop.Services
{
    /// <summary>Изпраща имейли чрез SendGrid.</summary>
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        /// <summary>Инициализира изпращача на имейли.</summary>
        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>Изпраща имейл асинхронно.</summary>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _config["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("andontakev@gmail.com", "PresAndo Shop");
            var to = new EmailAddress(email);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlMessage);
            var response = await client.SendEmailAsync(msg);
            var body = await response.Body.ReadAsStringAsync();
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(body);

            
        }
    }


}

