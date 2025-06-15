using SportReserveServer.Models;

namespace SportReserveServer.Interfaces
{
    public interface IUserValidator
    {
        void ValidateUser(AddUserDto? user);
    }
}
