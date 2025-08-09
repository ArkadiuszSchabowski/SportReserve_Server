using SportReserve_Emails.Models;

namespace SportReserve_Emails.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailToAdmin(SendEmailToAdminDto dto);
    }
}
