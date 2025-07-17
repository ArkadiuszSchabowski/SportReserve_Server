using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.User;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users.Interfaces.Aggregates
{
    public interface IUserAggregateValidator : IEntityValidator<User>, IValidatorInput<RegisterDto>, IUserValidator, ILoginValidator, IValidatorId, IEmailValidator
    {
    }
}
