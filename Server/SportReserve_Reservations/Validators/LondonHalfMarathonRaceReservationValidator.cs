using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Validators
{
    public class LondonHalfMarathonRaceReservationValidator : ILondonHalfMarathonRaceReservationValidator
    {
        private readonly IReservationValidator _reservationValidator;

        public LondonHalfMarathonRaceReservationValidator(IReservationValidator reservationValidator)
        {
            _reservationValidator = reservationValidator;
        }

        public void ValidateLondonHalfMarathonRaceReservation(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string userId, string userIdFromToken)
        {
            string raceName = "London Half-Marathon Race";

            _reservationValidator.ValidateRace(getRaceDto, getRaceTraceDto, raceName, userId, userIdFromToken);
        }
    }
}
