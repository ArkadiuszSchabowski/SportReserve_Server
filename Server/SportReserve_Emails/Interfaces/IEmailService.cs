

using SportReserve_Shared.Models.Email;

namespace SportReserve_Emails.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailToAdmin(SendEmailToAdminDto dto);
    }
}
