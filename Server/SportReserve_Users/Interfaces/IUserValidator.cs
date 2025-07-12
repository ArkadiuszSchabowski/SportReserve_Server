using SportReserve_Shared.Models;

namespace SportReserveServer.Interfaces
{
    public interface IUserValidator
    {
        void ValidateUser(RegisterDto? user);
    }
}
