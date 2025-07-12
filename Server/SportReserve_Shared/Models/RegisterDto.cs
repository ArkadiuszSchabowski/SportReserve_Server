using SportReserve_Shared.Enums;

namespace SportReserve_Shared.Models
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RepeatPassword { get; set; } = string.Empty;
        public Gender? Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
