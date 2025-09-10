namespace SportReserve_Races_Db.Entities
{
    public class RaceTrace
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public TimeOnly HourOfStart { get; set; }
        public double DistanceKm { get; set; }
        public int? Slots { get; set; }
        public virtual Race? Race { get; set; }
        public int ParentRaceId { get; set; }
    }
}
