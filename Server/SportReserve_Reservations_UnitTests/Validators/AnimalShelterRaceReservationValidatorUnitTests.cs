using Moq;
using SportReserve_Reservations.Interfaces;
using SportReserve_Reservations.Validators;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class AnimalShelterRaceReservationValidatorUnitTests
    {
        private readonly Mock<IReservationValidator> _mockReservationValidator;
        public AnimalShelterRaceReservationValidatorUnitTests()
        {
            _mockReservationValidator = new Mock<IReservationValidator>();
        }
        [Fact]
        public void ValidateAnimalShelterRaceReservation_WhenCalled_ShouldInvokeValidateRaceOnce()
        {
            var raceValidator = new AnimalShelterRaceReservationValidator(_mockReservationValidator.Object);

            var getRaceDto = new GetRaceDto();
            var getRaceTraceDto = new GetRaceTraceDto();
            var raceName = "Run for the Animal Shelter";
            var userId = "1";
            var userIdFromToken = "1";
            raceValidator.ValidateAnimalShelterRaceReservation(getRaceDto, getRaceTraceDto, userId, userIdFromToken);

            _mockReservationValidator.Verify(x => x.ValidateRace(getRaceDto, getRaceTraceDto, raceName, userId, userIdFromToken), Times.Once);
        }
    }
}
