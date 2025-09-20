using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    [BsonDiscriminator("ValentineRace")]
    public class ValentineRace : ReservationBase
    {
        public string RaceName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public TimeOnly HourOfStart { get; set; }
        public double DistanceKm { get; set; }
        public string ValentineGadget { get; set; } = string.Empty;

        public string RunType { get; set; } = string.Empty;
        public bool WantsFinisherPhoto { get; set; } = false;
    }
}
