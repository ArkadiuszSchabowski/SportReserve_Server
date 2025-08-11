using AutoMapper;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Models.Race;
using SportReserveServer.Interfaces;

namespace SportReserve_Races.Services
{
    public class RaceTraceService : IRaceTraceAggregateService
    {
        private readonly IRepository<RaceTrace> _repository;
        private readonly IRaceTraceAggregateValidator _validator;
        private readonly IMapper _mapper;

        public RaceTraceService(IRepository<RaceTrace> repository, IRaceTraceAggregateValidator validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task Add(AddRaceTraceDto dto)
        {
            _validator.ValidateRaceTrace(dto);

            RaceTrace raceDetails = _mapper.Map<RaceTrace>(dto);

            await _repository.Add(raceDetails);
        }

        public async Task<List<GetRaceTraceDto>> Get()
        {
            var raceTraces = await _repository.Get();

            var dto = _mapper.Map<List<GetRaceTraceDto>>(raceTraces);

            return dto;
        }

        public async Task<GetRaceTraceDto> Get(int id)
        {
            _validator.ValidateId(id);

            var raceTrace = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(raceTrace);

            var dto = _mapper.Map<GetRaceTraceDto>(raceTrace);

            return dto;
        }

        public async Task Remove(int id)
        {
            _validator.ValidateId(id);

            var raceTrace = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(raceTrace!);

            await _repository.Remove(raceTrace!);
        }
    }
}
