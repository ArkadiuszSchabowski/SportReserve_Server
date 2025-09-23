using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Validators
{
    public class ReservationValidator : IReservationValidator
    {
        public void ValidateRace(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string raceName, string userId, string userIdFromToken)
        {
            if (getRaceDto!.Name != raceName)
            {
                throw new BadRequestException("The provided race details do not match the expected race.");
            }

            if (getRaceDto!.Id != getRaceTraceDto!.ParentRaceId)
            {
                throw new BadRequestException("Race does not contain the specified race trace.");
            }

            if (userId != userIdFromToken)
            {
                throw new ForbiddenException("Cannot create a reservation for another user.");
            }
        }
    }
}
