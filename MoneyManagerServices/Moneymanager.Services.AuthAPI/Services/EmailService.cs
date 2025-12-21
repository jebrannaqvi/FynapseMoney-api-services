using Moneymanager.Services.AuthAPI.Services.IService;

namespace Moneymanager.Services.AuthAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailSettings = _configuration.GetSection("EmailConfiguration");
            var login = emailSettings.GetValue<string>("Login");
            var password = emailSettings.GetValue<string>("Password");
            var smtpServer = emailSettings.GetValue<string>("SmtpServer");
            var port = emailSettings.GetValue<int>("Port");

            using (var client = new System.Net.Mail.SmtpClient(smtpServer, port))
            {
                client.Credentials = new System.Net.NetworkCredential(login, password);
                client.EnableSsl = true;

                var mailMessage = new System.Net.Mail.MailMessage
                {
                    From = new System.Net.Mail.MailAddress(login),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }

        }
    }
}
