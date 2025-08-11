namespace SportReserve_Shared.Models.Race
{
    public class GetRaceTraceDto
    {
        public int Id { get; set; }
        public DateOnly DateOfStart { get; set; }
        public TimeOnly HourOfStart { get; set; }
        public string Location { get; set; } = string.Empty;
        public double DistanceKm { get; set; }
        public double? EntryFeeGBP { get; set; }
        public int? Slots { get; set; }
        public bool IsRegistrationOpen { get; set; }
        public int ParentRaceId { get; set; }
    }
}
