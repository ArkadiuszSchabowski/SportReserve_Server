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

            if (string.IsNullOrWhiteSpace(dto!.Name) || dto.Name.Length < 5 || dto.Name.Length > 50)
            {
                throw new BadRequestException("Race name must be between 5 and 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(dto.Place) || dto.Place.Length < 3 || dto.Place.Length > 25)
            {
                throw new BadRequestException("Race place must be between 3 and 25 characters.");
            }

            if (string.IsNullOrWhiteSpace(dto.City) || dto.City.Length < 3 || dto.City.Length > 25)
            {
                throw new BadRequestException("Race city must be between 3 and 25 characters.");
            }

            if (dto.DateOfStart < DateOnly.FromDateTime(DateTime.Now))
            {
                throw new BadRequestException("Incorrect date of start.");
            }

            if (dto.Slots < 10 || dto.Slots > 50000)
            {
                throw new BadRequestException("Race slots must be between 10 and 50000.");
            }

            if(dto.IsRegistrationOpen == false)
            {
                throw new BadRequestException("Registration for this race is closed.");
            }

            if(dto.Distance < 0.1 || dto.Distance > 100)
            {
                throw new BadRequestException("Race distance must be between 0.1km and 100km.");
            }
        }
    }
}
