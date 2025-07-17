using SportReserve_Shared.Models.User;

namespace SportReserve_Users.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwt(LoginDto dto);
    }
}
