using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation.Add
{
    public class AddLondonHalfMarathonRace : ReservationBase
    {
        public string TShirtSize { get; set; } = string.Empty;

        public string? TeamName;
        public bool MedalGratification { get; set; } = false;
    }
}
