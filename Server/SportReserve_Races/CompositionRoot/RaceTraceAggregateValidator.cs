using SportReserve_Races.Interfaces;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.CompositionRoot
{
    public class RaceTraceAggregateValidator : IRaceTraceAggregateValidator
    {
        private readonly IRaceTraceValidator _raceTraceValidator;
        private readonly IValidatorId _validatorId;
        private readonly IValidatorInput<AddRaceTraceDto> _validatorInput;
        private readonly IEntityNullValidator<RaceTrace> _entityNullValidator;

        public RaceTraceAggregateValidator(IRaceTraceValidator raceTraceValidator, IValidatorId validatorId, IValidatorInput<AddRaceTraceDto> validatorInput, IEntityNullValidator<RaceTrace> entityNullValidator)
        {
            _raceTraceValidator = raceTraceValidator;
            _validatorId = validatorId;
            _validatorInput = validatorInput;
            _entityNullValidator = entityNullValidator;

        }

        public void ThrowIfDtoIsNull(AddRaceTraceDto? dto)
        {
            _validatorInput.ThrowIfDtoIsNull(dto);
        }

        public void ThrowIfEntityIsNull(RaceTrace? entity)
        {
            _entityNullValidator.ThrowIfEntityIsNull(entity);
        }

        public void ValidateId(int id)
        {
            _validatorId.ValidateId(id);
        }

        public void ThrowIfParentIdNotExist(Race? dto)
        {
            _raceTraceValidator.ThrowIfParentIdNotExist(dto);
        }

        public void ValidateRaceTrace(AddRaceTraceDto? dto)
        {
            _raceTraceValidator.ValidateRaceTrace(dto);
        }
    }
}
