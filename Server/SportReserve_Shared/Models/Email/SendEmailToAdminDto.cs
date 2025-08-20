namespace SportReserve_Shared.Models.Email
{
    public class SendEmailToAdminDto
    {
        public string From { get; set; } = string.Empty;

        public string Subject { get; set; } = string.Empty;
        public string Message {  get; set; } = string.Empty;
    }
}
