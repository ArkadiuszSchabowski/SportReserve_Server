namespace SportReserveServer.Models
{
    public class AddUserDto
    {
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RepeatPassword { get; set; } = string.Empty;
        public bool? IsMale { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
