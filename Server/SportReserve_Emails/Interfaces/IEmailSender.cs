using SportReserve_Shared.Models.Email;
using SportReserve_Shared.Models.User;

namespace SportReserve_Emails.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailToAdmin(SendEmailToAdminDto dto);
        Task SendRegisterEmail(UserRegisteredEventDto dto);
    }
}
