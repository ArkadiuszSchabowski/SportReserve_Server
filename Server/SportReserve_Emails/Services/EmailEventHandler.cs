using FluentEmail.Core;
using FluentEmail.Smtp;
using SportReserve_Emails.Interfaces;
using SportReserve_Shared.Models.User;
using System.Net;
using System.Net.Mail;

namespace SportReserve_Emails.Services
{
    public class EmailEventHandler : IEmailEventHandler
    {
        private readonly EmailAuthentication _emailAuthentication;

        public EmailEventHandler(EmailAuthentication emailAuthentication)
        {
            _emailAuthentication = emailAuthentication;
        }
        public async Task SendRegisterEmail(UserRegisteredEventDto dto)
        {
                var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
                {
                    EnableSsl = true,
                    Port = 587,
                    Credentials = new NetworkCredential(_emailAuthentication.Email, _emailAuthentication.AppPassword)
                });

                Email.DefaultSender = sender;

                var email = await Email
                    .From(emailAddress: _emailAuthentication.Email)
                    .To(emailAddress: dto.Email)
                    .Subject("Registration")
                    .Body($"Welcome to our app, {dto.Name}! Your adventure starts today with us. You can reserve runs that interest you and track your progress. See you on the race track!")
                    .SendAsync();
        }
    }
}


