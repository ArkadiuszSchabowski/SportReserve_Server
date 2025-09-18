using MongoDB.Bson.Serialization.Attributes;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    [BsonDiscriminator("AnimalShelterRace")]
    public class AnimalShelterRace : ReservationBase
    {
        public string RaceName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public TimeOnly HourOfStart { get; set; }
        public double DistanceKm { get; set; }
        public string? DogSize { get; set; }
        public double? DonationAmount { get; set; }
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
