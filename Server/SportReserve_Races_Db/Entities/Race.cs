namespace SportReserve_Races_Db.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? PosterUrl { get; set; }
        public double? EntryFeeGBP { get; set; }
        public bool IsRegistrationOpen { get; set; } = false;
        public List<RaceTrace> RaceTraces { get; set; } = new();
    }
}