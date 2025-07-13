using SportReserve_Shared.Models.User;

namespace SportReserveServer.Interfaces
{
    public interface IGetByEmail
    {
        Task<GetUserDto> GetByEmail(string email);
    }
}
