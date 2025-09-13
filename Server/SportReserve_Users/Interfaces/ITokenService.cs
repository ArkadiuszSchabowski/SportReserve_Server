using SportReserve_Shared.Models.User;

namespace SportReserve_Users.Interfaces
{
    public interface ITokenService
    {
        Task<TokenDto> GenerateJwt(LoginDto dto);
    }
}
