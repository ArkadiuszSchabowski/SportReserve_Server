using FluentEmail.Core;
using SportReserve_Emails.Interfaces;
using SportReserve_Emails.Models;

namespace SportReserve_Emails.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailAuthentication _emailAuthentication;
        private readonly ISenderFactory _senderFactory;

        public EmailService(EmailAuthentication emailAuthentication, ISenderFactory senderFactory)
        {
            _emailAuthentication = emailAuthentication;
            _senderFactory = senderFactory;
        }
        public async Task SendEmailToAdmin(SendEmailToAdminDto dto)
        {
            _senderFactory.CreateSender();

            var email = await Email
                .From(emailAddress: _emailAuthentication.Email)
                .To(emailAddress: _emailAuthentication.Email)
                .Subject(dto.Subject)
                .Body($"Message from: {dto.From}, {dto.Message}")
                .SendAsync();
        }
    }
}
