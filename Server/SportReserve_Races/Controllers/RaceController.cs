using Microsoft.AspNetCore.Mvc;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Shared.Models.Pagination;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : ControllerBase
    {
        private readonly IRaceAggregateService _service;
        public RaceController(IRaceAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetRaceDto>>> Get([FromQuery] PaginationDto dto)
        {
            var races = await _service.Get(dto);
            return Ok(races);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRaceDto>> Get([FromRoute] int id)
        {
            var race = await _service.Get(id);
            return Ok(race);
        }

        [HttpGet("by-name")]
        public async Task<ActionResult<GetRaceDto>> Get([FromQuery] string name)
        {
            var race = await _service.GetByName(name);
            return Ok(race);
        }

        [HttpPost("add")]
        public async Task<ActionResult> Add([FromBody] AddRaceDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _service.Remove(id);
            return NoContent();
        }
    }
}
