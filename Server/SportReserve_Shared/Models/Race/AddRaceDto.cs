using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.Race
{
    public class AddRaceDto
    {
        [Required(ErrorMessage = "Race name is required.")]
        [MinLength(5, ErrorMessage = "Race name must be between 5 and 100 characters.")]
        [MaxLength(100, ErrorMessage = "Race name must be between 5 and 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public string? PosterUrl { get; set; } = "/images/default_poster.png";
    }
}