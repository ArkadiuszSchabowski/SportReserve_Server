using SportReserve_Shared.Models.Reservation.Base;
using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.Reservation.Add
{
    public class AddValentineRace : ReservationBase
    {
        [Required]
        public string ValentineGadget { get; set; } = string.Empty;

        [Required]
        public string RunType { get; set; } = string.Empty;

        public bool WantsFinisherPhoto { get; set; } = false;
    }
}
