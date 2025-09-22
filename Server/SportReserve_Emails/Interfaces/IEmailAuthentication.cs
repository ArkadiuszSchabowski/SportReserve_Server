namespace SportReserve_Emails.Interfaces
{
    public interface IEmailAuthentication
    {
        public string Email { get; set; }
        public string AppPassword { get; set; }
    }
}
