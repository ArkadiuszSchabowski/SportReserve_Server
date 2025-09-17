using SportReserve_Shared.Models.Reservation.Base;
using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.Reservation.Add
{
    public class AddLondonHalfMarathonRace : ReservationBase
    {
        [Required]
        public string TShirtSize { get; set; } = string.Empty;

        public string? TeamName;
        public bool MedalGratification { get; set; } = false;
    }
}
