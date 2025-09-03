using SportReserve_Shared.Enums;

namespace SportReserve_Users_Db.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public virtual Role? Role { get; set; }
        public int RoleId { get; set; }
    }
}
