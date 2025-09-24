using AutoMapper;
using Moq;
using SportReserve_Races.Interfaces.Aggregates;
using SportReserve_Races.Services;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Exceptions;
using SportReserve_Shared.Models.Race;
using SportReserve_Shared.Models.Reservation;

namespace SportReserve_Races_UnitTests.Services
{
    [Trait("Category", "Unit")]
    public class RaceServiceUnitTests
    {
        private readonly Mock<IRaceAggregateRepository> _mockRaceRepository;
        private readonly Mock<IRaceAggregateValidator> _mockRaceValidator;
        private readonly Mock<IMapper> _mockMapper;
        public RaceServiceUnitTests()
        {
            _mockRaceRepository = new Mock<IRaceAggregateRepository>();
            _mockRaceValidator = new Mock<IRaceAggregateValidator>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public async Task Add_WhenCalled_ShouldInvokeRepositoryAddOnce()
        {
            var raceService = new RaceService(_mockRaceRepository.Object, _mockRaceValidator.Object, _mockMapper.Object);

            var dto = new AddRaceDto
            {
                Name = "Valentine Race",
            };

            Race? race = null;
            var newRace = new Race();

            _mockRaceRepository.Setup(x => x.Get(dto.Name)).ReturnsAsync(race);
            _mockMapper.Setup(x => x.Map<Race>(dto)).Returns(newRace);

            await raceService.Add(dto);

            _mockRaceRepository.Verify(x => x.Add(newRace), Times.Once);
        }

        [Fact]
        public async Task Add_WhenCalled_ShouldInvokeMapFromAddRaceDtoToRaceOnce()
        {
            var raceService = new RaceService(_mockRaceRepository.Object, _mockRaceValidator.Object, _mockMapper.Object);

            var dto = new AddRaceDto
            {
                Name = "Valentine Race",
            };

            Race? race = null;
            var newRace = new Race();

            _mockRaceRepository.Setup(x => x.Get(dto.Name)).ReturnsAsync(race);
            _mockMapper.Setup(x => x.Map<Race>(dto)).Returns(newRace);

            await raceService.Add(dto);

            _mockMapper.Verify(x => x.Map<Race>(dto), Times.Once);
        }
        [Fact]
        public async Task Add_WhenRaceExistInDatabase_ShouldNotInvokeMapFromAddRaceDtoToRaceOnce()
        {
            var raceService = new RaceService(_mockRaceRepository.Object, _mockRaceValidator.Object, _mockMapper.Object);

            var dto = new AddRaceDto
            {
                Name = "Valentine Race",
            };

            Race? existingRace = new Race()
            {
                Name = "Valentine Race",
                DateOfStart = new DateOnly(2030, 2, 14)
            };

            _mockRaceRepository.Setup(x => x.Get(dto.Name)).ReturnsAsync(existingRace);
            _mockRaceValidator.Setup(x => x.ThrowIfEntityExist(existingRace)).Throws(new ConflictException("Race already exists in database."));

            var action = () => raceService.Add(dto);

            await Assert.ThrowsAsync<ConflictException>(action);

            _mockMapper.Verify(x => x.Map<Race>(dto), Times.Never);
        }
        [Fact]
        public async Task Add_WhenRaceExistInDatabase_ShouldNotInvokeRepositoryAdd()
        {
            var raceService = new RaceService(_mockRaceRepository.Object, _mockRaceValidator.Object, _mockMapper.Object);

            var dto = new AddRaceDto
            {
                Name = "Valentine Race",
            };

            Race? existingRace = new Race()
            {
                Name = "Valentine Race",
                DateOfStart = new DateOnly(2030, 2, 14)
            };

            var newRace = new Race();

            _mockRaceRepository.Setup(x => x.Get(dto.Name)).ReturnsAsync(existingRace);
            _mockRaceValidator.Setup(x => x.ThrowIfEntityExist(existingRace)).Throws(new ConflictException("Race already exists in database."));

            var action = () => raceService.Add(dto);

            await Assert.ThrowsAsync<ConflictException>(action);

            _mockRaceRepository.Verify(x => x.Add(newRace), Times.Never);
        }
    }
}
