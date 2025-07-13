using SportReserve_Shared.Models.User;

namespace SportReserveServer.Interfaces
{
    public interface IUserValidator
    {
        void ValidateUser(RegisterDto? user);
    }
}
