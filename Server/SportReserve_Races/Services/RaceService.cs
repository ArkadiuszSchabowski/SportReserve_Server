using AutoMapper;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Models.Pagination;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Services
{
    public class RaceService : IRaceAggregateService
    {
        private readonly IRaceAggregateRepository _repository;
        private readonly IRaceAggregateValidator _validator;
        private readonly IMapper _mapper;

        public RaceService(IRaceAggregateRepository repository, IRaceAggregateValidator validator, IMapper mapper)
        {
            _repository = repository;
            _validator = validator;
            _mapper = mapper;
        }
        public async Task Add(AddRaceDto dto)
        {
            _validator.ValidateRace(dto);

            Race? race = await _repository.Get(dto.Name);

            _validator.ThrowIfEntityExist(race);

            Race newRace = _mapper.Map<Race>(dto);

            await _repository.Add(newRace);
        }
        public async Task<PaginationResult<GetRaceDto>> Get(PaginationDto paginationDto)
        {
            var totalCounts = await _repository.CountRecords();

            var races = await _repository.Get(paginationDto);

            var racesDto = _mapper.Map<List<GetRaceDto>>(races);

            var dto = new PaginationResult<GetRaceDto>
            {
                TotalCount = totalCounts,
                Results = racesDto
            };

            return dto;
        }

        public async Task<GetRaceDto> Get(int id)
        {
            _validator.ValidateId(id);

            var race = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(race);

            var dto = _mapper.Map<GetRaceDto>(race);

            return dto;
        }

        public async Task<GetRaceDto> GetByName(string name)
        {
            var race = await _repository.Get(name);

            _validator.ThrowIfEntityIsNull(race);

            var dto = _mapper.Map<GetRaceDto>(race);

            return dto;
        }

        public async Task Remove(int id)
        {
            _validator.ValidateId(id);

            var race = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(race!);

            await _repository.Remove(race!);
        }

        public async Task Update(int id, UpdateRaceDto dto)
        {
            _validator.ValidateId(id);
            _validator.ValidateUpdatedRace(dto);

            var race = await _repository.Get(id);

            _validator.ThrowIfEntityIsNull(race);

            _mapper.Map(dto, race);

            await _repository.SaveChangesAsync();
        }
    }
}
