using SportReserve_Shared.Models.User;

namespace SportReserve_Users.Interfaces
{
    public interface IUserValidator
    {
        void ValidateUser(RegisterDto? user);
    }
}
