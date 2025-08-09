using FluentEmail.Smtp;

namespace SportReserve_Emails.Interfaces
{
    public interface ISenderFactory
    {
        void CreateSender();
    }
}
