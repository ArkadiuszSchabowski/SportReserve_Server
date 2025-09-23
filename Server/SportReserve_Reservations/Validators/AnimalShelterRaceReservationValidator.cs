using SportReserve_Reservations.Interfaces;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations.Validators
{
    public class AnimalShelterRaceReservationValidator : IAnimalShelterRaceReservationValidator
    {
        private readonly IReservationValidator _reservationValidator;

        public AnimalShelterRaceReservationValidator(IReservationValidator reservationValidator)
        {
            _reservationValidator = reservationValidator;
        }

        public void ValidateAnimalShelterRaceReservation(GetRaceDto getRaceDto, GetRaceTraceDto getRaceTraceDto, string userId, string userIdFromToken)
        {
            string raceName = "Run for the Animal Shelter";

            _reservationValidator.ValidateRace(getRaceDto, getRaceTraceDto, raceName, userId, userIdFromToken);
        }
    }
}
