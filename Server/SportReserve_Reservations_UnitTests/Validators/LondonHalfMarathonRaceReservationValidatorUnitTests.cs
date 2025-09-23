using Moq;
using SportReserve_Reservations.Interfaces;
using SportReserve_Reservations.Validators;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class LondonHalfMarathonRaceReservationValidatorUnitTests
    {
        private readonly Mock<IReservationValidator> _mockReservationValidator;

        public LondonHalfMarathonRaceReservationValidatorUnitTests()
        {
            _mockReservationValidator = new Mock<IReservationValidator>();
        }

        [Fact]
        public void ValidateLondonHalfMarathonRaceReservation_WhenCalled_ShouldInvokeValidateRaceOnce()
        {
            var raceValidator = new LondonHalfMarathonRaceReservationValidator(_mockReservationValidator.Object);

            var getRaceDto = new GetRaceDto();
            var getRaceTraceDto = new GetRaceTraceDto();
            var raceName = "London Half-Marathon Race";
            var userId = "1";
            var userIdFromToken = "1";

            raceValidator.ValidateLondonHalfMarathonRaceReservation(getRaceDto, getRaceTraceDto, userId, userIdFromToken);

            _mockReservationValidator.Verify(x => x.ValidateRace(getRaceDto, getRaceTraceDto, raceName, userId, userIdFromToken), Times.Once);
        }
    }
}
