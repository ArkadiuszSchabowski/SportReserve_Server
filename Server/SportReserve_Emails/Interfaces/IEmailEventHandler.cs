using SportReserve_Shared.Models.User;

namespace SportReserve_Emails.Interfaces
{
    public interface IEmailEventHandler
    {
        Task SendRegisterEmail(UserRegisteredEventDto dto);
    }
}
