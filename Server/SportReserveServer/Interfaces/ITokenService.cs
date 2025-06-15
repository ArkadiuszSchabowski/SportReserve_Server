using SportReserveServer.Models;

namespace SportReserveServer.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwt(LoginDto dto);
    }
}
