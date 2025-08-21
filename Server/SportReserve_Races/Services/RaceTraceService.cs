using AutoMapper;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Services
{
    public class RaceTraceService : IRaceTraceAggregateService
    {
        private readonly IRaceTraceAggregateRepository _raceTraceRepository;
        private readonly IRaceTraceAggregateValidator _validator;
        private readonly IMapper _mapper;

        public RaceTraceService(IRaceTraceAggregateRepository raceTraceRepository, IRaceTraceAggregateValidator validator, IMapper mapper)
        {
            _raceTraceRepository = raceTraceRepository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task Add(AddRaceTraceDto dto)
        {
           var race = await _raceTraceRepository.GetParent(dto.ParentRaceId);

            _validator.ThrowIfParentIdNotExist(race);

            _validator.ValidateRaceTrace(dto);

            RaceTrace raceDetails = _mapper.Map<RaceTrace>(dto);

            await _raceTraceRepository.Add(raceDetails);
        }

        public async Task<List<GetRaceTraceDto>> Get()
        {
            var raceTraces = await _raceTraceRepository.Get();

            var dto = _mapper.Map<List<GetRaceTraceDto>>(raceTraces);

            return dto;
        }

        public async Task<GetRaceTraceDto> Get(int id)
        {
            _validator.ValidateId(id);

            var raceTrace = await _raceTraceRepository.Get(id);

            _validator.ThrowIfEntityIsNull(raceTrace);

            var dto = _mapper.Map<GetRaceTraceDto>(raceTrace);

            return dto;
        }

        public async Task Remove(int id)
        {
            _validator.ValidateId(id);

            var raceTrace = await _raceTraceRepository.Get(id);

            _validator.ThrowIfEntityIsNull(raceTrace!);

            await _raceTraceRepository.Remove(raceTrace!);
        }
    }
}
