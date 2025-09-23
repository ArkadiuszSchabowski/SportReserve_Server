using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Validators
{
    public class ValentineRaceReservationValidator : IValentineRaceReservationValidator
    {
        private readonly IReservationValidator _reservationValidator;

        public ValentineRaceReservationValidator(IReservationValidator reservationValidator)
        {
            _reservationValidator = reservationValidator;
        }

        public void ValidateValentineRaceReservation(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string userId, string userIdFromToken)
        {
            string raceName = "Valentine Race with Heart";

            _reservationValidator.ValidateRace(getRaceDto, getRaceTraceDto, raceName, userId, userIdFromToken);
        }
    }
}
