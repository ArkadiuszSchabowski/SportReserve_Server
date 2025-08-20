using Microsoft.AspNetCore.Mvc;
using SportReserve_Emails.Interfaces;
using SportReserve_Shared.Models.Email;

namespace SportReserve_Emails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;

        public EmailController(IEmailService service)
        {
            _service = service;
        }
        [HttpPost("send")]
        public async Task<ActionResult> SendEmailToAdmin([FromBody] SendEmailToAdminDto dto)
        {
            await _service.SendEmailToAdmin(dto);
            return Ok();
        }
    }
}
