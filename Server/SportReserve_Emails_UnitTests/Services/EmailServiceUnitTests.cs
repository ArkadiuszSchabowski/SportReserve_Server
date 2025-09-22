using Moq;
using SportReserve_Emails.Interfaces;
using SportReserve_Emails.Services;
using SportReserve_Shared.Models.Email;
using SportReserve_Shared.Models.User;
using SportReserve_Shared.Enums;

namespace SportReserve_Emails_UnitTests.Services
{
    [Trait("Category", "Unit")]
    public class EmailServiceUnitTests
    {
        private readonly Mock<IEmailSender> _emailSender;
        public EmailServiceUnitTests()
        {
            _emailSender = new Mock<IEmailSender>();
        }
        [Fact]
        public async Task SendEmailToAdmin_WhenCalled_ShouldInvokeSendEmailToAdminOnce()
        {
            var emailService = new EmailService(_emailSender.Object);

            var dto = new SendEmailToAdminDto
            {
                From = "server@gmail.com",
                Subject = "Test message",
                Message = "This is a simple test message"
            };

            await emailService.SendEmailToAdmin(dto);

            _emailSender.Verify(x => x.SendEmailToAdmin(dto), Times.Once());
        }

        [Fact]
        public async Task SendRegisterEmail_WhenCalled_SendRegisterEmailOnce()
        {
            var emailService = new EmailService(_emailSender.Object);

            var dto = new UserRegisteredEventDto
            {
                Id = 1,
                Gender = Gender.Male,
                Email = "john@gmail.com",
                Name = "John",
                Surname = "Thompson",
                DateOfBirth = new DateOnly(1990, 1, 1)
            };

            await emailService.SendRegisterEmail(dto);

            _emailSender.Verify(x => x.SendRegisterEmail(dto), Times.Once());
        }
    }
}
