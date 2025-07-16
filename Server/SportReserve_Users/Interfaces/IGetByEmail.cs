using SportReserve_Shared.Models.User;

namespace SportReserve_Users.Interfaces
{
    public interface IGetByEmail
    {
        Task<GetUserDto> GetByEmail(string email);
    }
}
