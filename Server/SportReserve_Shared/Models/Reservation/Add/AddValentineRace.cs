using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation.Add
{
    public class AddValentineRace : ReservationBase
    {
        public string ValentineGadget { get; set; } = string.Empty;

        public string RunType = string.Empty;
        public bool WantsFinisherPhoto { get; set; } = false;
    }
}
