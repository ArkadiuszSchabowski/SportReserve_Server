using FluentEmail.Core;
using SportReserve_Emails.Interfaces;
using SportReserve_Shared.Models.User;

namespace SportReserve_Emails.Services
{
    public class EmailEventHandler : IEmailEventHandler
    {
        private readonly EmailAuthentication _emailAuthentication;
        private readonly ISenderFactory _senderFactory;

        public EmailEventHandler(EmailAuthentication emailAuthentication, ISenderFactory senderFactory)
        {
            _emailAuthentication = emailAuthentication;
            _senderFactory = senderFactory;
        }

        public async Task SendRegisterEmail(UserRegisteredEventDto dto)
        {
            _senderFactory.CreateSender();

            var email = await Email
                .From(emailAddress: _emailAuthentication.Email)
                .To(emailAddress: dto.Email)
                .Subject("Registration")
                .Body($"Welcome to our app, {dto.Name}! Your adventure starts today with us. You can reserve runs that interest you and track your progress. See you on the race track!")
                .SendAsync();
        }
    }
}


