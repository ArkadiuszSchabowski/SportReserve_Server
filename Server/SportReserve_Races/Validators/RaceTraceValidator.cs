using SportReserve_Races.Interfaces;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Validators
{
    public class RaceTraceValidator : IRaceTraceValidator, IValidatorInput<AddRaceTraceDto>, IEntityNullValidator<RaceTrace>
    {
        public void ThrowIfDtoIsNull(AddRaceTraceDto? dto)
        {
            if (dto == null)
            {
                throw new NotFoundException("Race trace data is required.");
            }
        }

        public void ThrowIfEntityIsNull(RaceTrace? entity)
        {
            if (entity == null)
            {
                throw new NotFoundException("Race trace not found.");
            }
        }

        public void ThrowIfParentIdNotExist(Race? dto)
        {
            if (dto == null)
            {
                throw new BadRequestException("Parent race id not found.");
            }
        }

        public void ValidateRaceTrace(AddRaceTraceDto? dto)
        {
            ThrowIfDtoIsNull(dto);

            if (string.IsNullOrWhiteSpace(dto!.Location) || dto.Location.Length < 10 || dto.Location.Length > 100)
            {
                throw new BadRequestException("Location must be between 10 and 100 characters.");
            }


            if (dto.DistanceKm < 0.1 || dto.DistanceKm > 200)
            {
                throw new BadRequestException("Race distance must be between 0.1km and 200km.");
            }

            if(dto.ParentRaceId < 1)
            {
                throw new BadRequestException("Parent race id should be greater than 0.");
            }
        }
    }
}
