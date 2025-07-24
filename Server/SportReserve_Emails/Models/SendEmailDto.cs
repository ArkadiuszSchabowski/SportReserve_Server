namespace SportReserve_Emails.Models
{
    public class SendEmailDto
    {
        public string Recipient { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
