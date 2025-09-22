using SportReserve_Emails.Interfaces;
using SportReserve_Shared.Models.Email;
using SportReserve_Shared.Models.User;
namespace SportReserve_Emails.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailSender _emailSender;

        public EmailService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task SendEmailToAdmin(SendEmailToAdminDto dto)
        {
            await _emailSender.SendEmailToAdmin(dto);
        }
        public async Task SendRegisterEmail(UserRegisteredEventDto dto)
        {
            await _emailSender.SendRegisterEmail(dto);
        }
    }
}
