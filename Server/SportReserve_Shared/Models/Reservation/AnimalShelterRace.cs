using MongoDB.Bson.Serialization.Attributes;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    [BsonDiscriminator("AnimalShelterRace")]
    public class AnimalShelterRace : ReservationBase
    {
        public string? DogSize { get; set; }
        public int? DonationAmount { get; set; }
        public string EmergencyContact { get; set; } = string.Empty;
    }
}
