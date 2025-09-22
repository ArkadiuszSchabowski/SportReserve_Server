using SportReserve_Emails.Interfaces;

namespace SportReserve_Emails
{
    public class EmailAuthentication : IEmailAuthentication
    {
        public string Email { get; set; } = string.Empty;
        public string AppPassword { get; set; } = string.Empty;
    }
}
