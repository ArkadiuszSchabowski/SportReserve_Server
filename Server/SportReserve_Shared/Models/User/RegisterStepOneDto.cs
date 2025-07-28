using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.User
{
    public class RegisterStepOneDto
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(5, ErrorMessage = "Password must be between 5 and 25 characters.")]
        [MaxLength(25, ErrorMessage = "Password must be between 5 and 25 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Repeat password is required.")]
        [MinLength(5, ErrorMessage = "Repeat password must be between 5 and 25 characters.")]
        [MaxLength(25, ErrorMessage = "Repeat password must be between 5 and 25 characters.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string RepeatPassword { get; set; } = string.Empty;
    }
}