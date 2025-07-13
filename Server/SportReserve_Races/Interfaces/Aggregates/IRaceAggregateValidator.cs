using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;

namespace SportReserve_Races.Interfaces.Aggregates
{
    public interface IRaceAggregateValidator : IRaceValidator, IEntityValidator<Race>, IValidatorId
    {
    }
}
