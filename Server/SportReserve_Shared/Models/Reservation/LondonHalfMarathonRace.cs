using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    [BsonDiscriminator("LondonHalfMarathonRace")]
    public class LondonHalfMarathonRace : ReservationBase
    {
        public string TShirtSize { get; set; } = string.Empty;

        public string? TeamName;
        public bool MedalGratification { get; set; } = false;
    }
}
