using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    [BsonDiscriminator("LondonHalfMarathonRace")]
    public class LondonHalfMarathonRace : ReservationBase
    {
        public string RaceName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public TimeOnly HourOfStart { get; set; }
        public double DistanceKm { get; set; }
        public string? TShirtSize { get; set; }
        public string? TeamName { get; set; }
        public bool MedalGratification { get; set; } = false;
    }
}
