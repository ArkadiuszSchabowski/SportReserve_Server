namespace SportReserve_Shared.Models.Race
{
    public class GetRaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? PosterUrl { get; set; }
        public double? EntryFeeGBP { get; set; }
        public bool? IsRegistrationOpen { get; set; }
        public List<GetRaceTraceDto> RaceTraces { get; set; } = new ();
    }
}
