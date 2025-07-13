using SportReserve_Shared.Models.User;

namespace SportReserveServer.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwt(LoginDto dto);
    }
}
