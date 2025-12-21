namespace Moneymanager.Services.AuthAPI.Services.IService
{
    public interface IEmailService
    {
        public Task SendEmailAsync(string toEmail, string subject, string body);
    }
}
