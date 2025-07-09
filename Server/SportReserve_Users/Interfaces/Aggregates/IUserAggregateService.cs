using SportReserve_Shared.Models;

namespace SportReserveServer.Interfaces.Aggregates
{
    public interface IUserAggregateService :
    IAddService<AddUserDto>,
    IGetService<GetUserDto>,
    IGetByEmail,
    IRemoveService,
    ITokenService
    { }
}
