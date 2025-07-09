using SportReserveDatabase.Entities;
using SportReserveServer.Interfaces.Base;

namespace SportReserveServer.Interfaces.Aggregates
{
    public interface IUserAggregateValidator : IEntityValidator<User>, IUserValidator, ILoginValidator, IValidatorId, IEmailValidator
    {
    }
}
