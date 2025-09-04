using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceTraceController : ControllerBase
    {
        private readonly IRaceTraceAggregateService _service;
        public RaceTraceController(IRaceTraceAggregateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetRaceTraceDto>>> Get()
        {
            var raceTraces = await _service.Get();
            return Ok(raceTraces);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetRaceTraceDto>> Get([FromRoute] int id)
        {
            var raceTrace = await _service.Get(id);
            return Ok(raceTrace);
        }

        [HttpPost]
        [Authorize(Roles = "moderator,admin")]
        public async Task<ActionResult> Add([FromBody] AddRaceTraceDto dto)
        {
            await _service.Add(dto);
            return Ok();
        }

        [Authorize(Roles = "moderator,admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove([FromRoute] int id)
        {
            await _service.Remove(id);
            return NoContent();
        }
    }
}
