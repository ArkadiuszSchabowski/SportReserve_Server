using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserveDatabase.Entities;

namespace SportReserveServer.Interfaces.Aggregates
{
    public interface IUserAggregateValidator : IEntityValidator<User>, IUserValidator, ILoginValidator, IValidatorId, IEmailValidator
    {
    }
}
