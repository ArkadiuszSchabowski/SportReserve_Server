using SportReserve_Shared.Models.Reservation.Base;
using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.Reservation.Add
{
    public class AddAnimalShelterRace : ReservationBase
    {
        public string? DogSize { get; set; }
        public int? DonationAmount { get; set; }

        [Required]
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
