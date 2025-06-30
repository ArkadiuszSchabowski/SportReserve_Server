using SportReserve_Shared.Models;

namespace SportReserveServer.Interfaces
{
    public interface IGetByEmail
    {
        Task<GetUserDto> Get(string email);
    }
}
