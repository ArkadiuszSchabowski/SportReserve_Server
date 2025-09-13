using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    public class AnimalShelterRace : BaseRace
    {
        public int RaceTraceId { get; set; }
        public string? DogSize { get; set; }
        public int? DonationAmount { get; set; }
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
