using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces.Aggregates
{
    public interface IRaceAggregateValidator : IEntityValidator<Race>, IValidatorInput<AddRaceDto>,IRaceValidator, IValidatorId
    {
    }
}
