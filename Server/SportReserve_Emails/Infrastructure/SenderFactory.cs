using FluentEmail.Core;
using FluentEmail.Smtp;
using SportReserve_Emails.Interfaces;
using System.Net;
using System.Net.Mail;

namespace SportReserve_Emails.Infrastructure
{
    public class SenderFactory : ISenderFactory
    {
        private readonly IEmailAuthentication _emailAuthentication;

        public SenderFactory(IEmailAuthentication emailAuthentication)
        {
            _emailAuthentication = emailAuthentication;
        }
        public void CreateSender()
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential(_emailAuthentication.Email, _emailAuthentication.AppPassword)
            });

            Email.DefaultSender = sender;
        }
    }
}
