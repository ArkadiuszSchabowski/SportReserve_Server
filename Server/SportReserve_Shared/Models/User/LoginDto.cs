using System.ComponentModel.DataAnnotations;

namespace SportReserve_Shared.Models.User
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Repeat password is required.")]
        public string Password { get; set; } = string.Empty;
    }
}
