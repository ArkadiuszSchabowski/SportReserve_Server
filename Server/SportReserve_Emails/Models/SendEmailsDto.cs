namespace SportReserve_Emails.Models
{
    public class SendEmailsDto
    {
        public List<string> Recipients { get; set; } = new List<string>();
        public string Message { get; set; } = string.Empty;
    }
}
