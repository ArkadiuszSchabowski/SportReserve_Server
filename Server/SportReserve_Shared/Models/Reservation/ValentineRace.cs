using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SportReserve_Shared.Models.Reservation.Base;

namespace SportReserve_Shared.Models.Reservation
{
    [BsonDiscriminator("ValentineRace")]
    public class ValentineRace : ReservationBase
    {
        public string ValentineGadget { get; set; } = string.Empty;

        public string RunType = string.Empty;
        public bool WantsFinisherPhoto { get; set; } = false;
    }
}
