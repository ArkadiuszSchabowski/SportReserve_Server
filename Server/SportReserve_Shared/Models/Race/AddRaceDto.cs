namespace SportReserve_Shared.Models.Workout
{
    public class AddRaceDto
    {
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfStart { get; set; }
        public string City { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public double Distance { get; set; }
        public int Slots { get; set; }
        public bool IsRegistrationOpen { get; set; }
    }
}