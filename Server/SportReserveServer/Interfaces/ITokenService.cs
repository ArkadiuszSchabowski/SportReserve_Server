using SportReserve_Shared.Models;

namespace SportReserveServer.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwt(LoginDto dto);
    }
}
