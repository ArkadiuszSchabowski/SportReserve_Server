using SportReserve_Shared.Models.User;

namespace SportReserve_Users.Interfaces
{
    public interface IProducerUser
    {
            void RegisterEvent(UserRegisteredEventDto dto);
    }
}
