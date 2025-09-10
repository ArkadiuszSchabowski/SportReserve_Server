using SportReserve_Races.Interfaces;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Interfaces.Base;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Validators
{
    public class RaceValidator : IEntityValidator<Race>, IValidatorInput<AddRaceDto>, IRaceValidator
    {
        public void ThrowIfDtoIsNull(AddRaceDto? dto)
        {
            if (dto == null)
            {
                throw new NotFoundException("Race data is required.");
            }
        }

        public void ThrowIfEntityExist(Race? entity)
        {
            if (entity != null)
            {
                throw new ConflictException("Race already exists in database.");
            }
        }

        public void ThrowIfEntityIsNull(Race? dto)
        {
            if (dto == null)
            {
                throw new NotFoundException("Race not found.");
            }
        }

        public void ValidateRace(AddRaceDto? dto)
        {
            ThrowIfDtoIsNull(dto);

            if (string.IsNullOrWhiteSpace(dto!.Name) || dto.Name.Length < 5 || dto.Name.Length > 100)
            {
                throw new BadRequestException("Race name must be between 5 and 100 characters.");
            }

            if (string.IsNullOrWhiteSpace(dto!.Description) || dto.Description.Length < 400 || dto.Description.Length > 1000)
            {
                throw new BadRequestException("Description must be between 400 and 1000 characters.");
            }

            if (dto.DateOfStart < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new BadRequestException("Race start date cannot be in the past.");
            }
            if(dto.DateOfStart > DateOnly.Parse("2035-01-01"))
            {
                throw new BadRequestException($"Race start date is after the allowed maximum date of 2035-01-01.");
            }
        }

        public void ValidateUpdatedRace(UpdateRaceDto? dto)
        {

            if (string.IsNullOrWhiteSpace(dto!.Name) || dto.Name.Length < 5 || dto.Name.Length > 100)
            {
                throw new BadRequestException("Race name must be between 5 and 100 characters.");
            }

            if (string.IsNullOrWhiteSpace(dto!.Description) || dto.Description.Length < 400 || dto.Description.Length > 1000)
            {
                throw new BadRequestException("Description must be between 400 and 1000 characters.");
            }

            if (dto.DateOfStart < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new BadRequestException("Race start date cannot be in the past.");
            }
            if (dto.DateOfStart > DateOnly.Parse("2035-01-01"))
            {
                throw new BadRequestException($"Race start date is after the allowed maximum date of 2035-01-01.");
            }
        }
    }
}