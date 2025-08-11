namespace SportReserve_Races_Db.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? PosterUrl { get; set; }
        public List<RaceTrace> RaceTraces { get; set; } = new();
    }
}