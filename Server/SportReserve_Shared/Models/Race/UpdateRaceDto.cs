using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.Race
{
    public class UpdateRaceDto
    {
        [Required(ErrorMessage = "Race name is required.")]
        [MinLength(5, ErrorMessage = "Race name must be between 5 and 100 characters.")]
        [MaxLength(100, ErrorMessage = "Race name must be between 5 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateOnly DateOfStart { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [MinLength(400, ErrorMessage = "Description must be between 400 and 1000 characters.")]
        [MaxLength(1000, ErrorMessage = "Description must be between 400 and 1000 characters.")]
        public string Description { get; set; } = string.Empty;
        public string? PosterUrl { get; set; } = "/images/default_poster.png";
        public double? EntryFeeGBP { get; set; }
    }
}
