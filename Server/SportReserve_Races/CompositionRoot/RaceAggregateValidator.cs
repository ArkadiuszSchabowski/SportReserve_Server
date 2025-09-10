using SportReserve_Races.Interfaces;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.CompositionRoot
{
    public class RaceAggregateValidator : IRaceAggregateValidator
    {
        private readonly IEntityValidator<Race> _entityValidator;
        private readonly IValidatorInput<AddRaceDto> _validatorInput;
        private readonly IValidatorId _validatorId;
        private readonly IRaceValidator _raceValidator;

        public RaceAggregateValidator(IEntityValidator<Race> entityValidator, IValidatorInput<AddRaceDto> validatorInput, IValidatorId validatorId, IRaceValidator raceValidator)
        {
            _entityValidator = entityValidator;
            _validatorInput = validatorInput;
            _validatorId = validatorId;
            _raceValidator = raceValidator;
        }

        public void ThrowIfDtoIsNull(AddRaceDto? dto)
        {
            _validatorInput.ThrowIfDtoIsNull(dto);
        }

        public void ThrowIfEntityExist(Race? entity)
        {
            _entityValidator.ThrowIfEntityExist(entity);
        }

        public void ThrowIfEntityIsNull(Race? dto)
        {
            _entityValidator.ThrowIfEntityIsNull(dto);
        }

        public void ValidateId(int id)
        {
            _validatorId.ValidateId(id);
        }

        public void ValidateRace(AddRaceDto? entity)
        {
            _raceValidator.ValidateRace(entity);
        }

        public void ValidateUpdatedRace(UpdateRaceDto? dto)
        {
            _raceValidator.ValidateUpdatedRace(dto);
        }
    }
}
