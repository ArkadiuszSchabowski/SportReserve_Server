using SportReserve_Shared.Models;

namespace SportReserveServer.Interfaces.Aggregates
{
    public interface IUserAggregateService :
    IAddService<RegisterDto>,
    IGetService<GetUserDto>,
    IGetByEmail,
    IRemoveService,
    ITokenService
    { }
}
