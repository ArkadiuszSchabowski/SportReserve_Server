namespace SportReserve_Races_Db.Entities
{
    public class RaceTrace
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public TimeOnly HourOfStart { get; set; }
        public double DistanceKm { get; set; }
        public double? EntryFeeGBP { get; set; }
        public int? Slots { get; set; }
        public bool IsRegistrationOpen { get; set; } = true;
        public Race? Race { get; set; }
        public int ParentRaceId { get; set; }
    }
}
