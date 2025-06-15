using SportReserveServer.Models;

namespace SportReserveServer.Interfaces.Aggregates
{
    public interface IAccountAggregateService :
    IAddService<AddUserDto>,
    IGetService<GetUserDto>,
    IGetByEmail,
    IRemoveService,
    ITokenService
    { }
}
