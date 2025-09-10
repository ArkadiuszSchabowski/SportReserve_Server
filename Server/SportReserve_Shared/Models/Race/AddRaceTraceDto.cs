using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.Race
{
    public class AddRaceTraceDto
    {
        [Required(ErrorMessage = "Location is required.")]
        [MinLength(10, ErrorMessage = "Location must be between 10 and 100 characters.")]
        [MaxLength(100, ErrorMessage = "Location must be between 10 and 100 characters.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hour of start is required.")]
        public TimeOnly HourOfStart { get; set; }

        [Required(ErrorMessage = "Distance is required.")]
        [Range(0.1, 200, ErrorMessage = "Race distance must be between 0.1km and 200km.")]
        public double DistanceKm { get; set; }
        public int? Slots { get; set; }

        [Required(ErrorMessage = "Parent race id is required.")]
        public int ParentRaceId { get; set; }
    }
}
