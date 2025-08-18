namespace SportReserve_Shared.Models.Race
{
    public class GetRaceTraceDto
    {
        public int Id { get; set; }
        public string Location { get; set; } = string.Empty;
        public TimeOnly HourOfStart { get; set; }
        public double DistanceKm { get; set; }
        public int? Slots { get; set; }
        public bool IsRegistrationOpen { get; set; } = true;
        public int ParentRaceId { get; set; }
    }
}
