using SportReserveServer.Models;

namespace SportReserveServer.Interfaces
{
    public interface IGetByEmail
    {
        GetUserDto Get(string email);
    }
}
