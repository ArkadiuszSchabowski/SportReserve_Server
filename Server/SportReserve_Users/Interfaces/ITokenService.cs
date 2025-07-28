using SportReserve_Shared.Models.User;
using SportReserve_Users.Models;

namespace SportReserve_Users.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDto> GenerateJwt(LoginDto dto);
    }
}
