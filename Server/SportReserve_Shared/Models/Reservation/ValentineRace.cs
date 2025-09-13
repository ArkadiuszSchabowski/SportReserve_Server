using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    public class ValentineRace : BaseRace
    {
        public int RaceTraceId { get; set; }
        public string ValentineGadget { get; set; } = string.Empty;

        public string RunType = string.Empty;
        public bool WantsFinisherPhoto { get; set; } = false;
    }
}
