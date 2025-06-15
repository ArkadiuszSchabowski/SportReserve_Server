using Microsoft.AspNetCore.Mvc;
using SportReserveServer.Interfaces.Aggregates;
using SportReserveServer.Models;

namespace SportReserveServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountAggregateService _service;

        public AccountController(IAccountAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<GetUserDto>> Get()
        {
            return _service.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<GetUserDto> Get([FromRoute] int id)
        {
            return _service.Get(id);
        }

        [HttpGet("email")]
        public ActionResult<GetUserDto> Get([FromQuery] string email)
        {
            return _service.Get(email);
        }

        [HttpPost]
        public ActionResult Add([FromBody] AddUserDto dto)
        {
            _service.Add(dto);

            return Ok();
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] LoginDto dto)
        {
            var token = _service.GenerateJwt(dto);

            return Ok(token);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove([FromRoute] int id)
        {
            _service.Remove(id);

            return NoContent();
        }
    }
}
