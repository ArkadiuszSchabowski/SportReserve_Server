using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Models.User;

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
