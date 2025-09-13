using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    public class LondonHalfMarathonRace : BaseRace
    {
        public int RaceTraceId { get; set; }
        public string TShirtSize { get; set; } = string.Empty;

        public string? TeamName;
        public bool MedalGratification { get; set; } = false;
    }
}
