using Moq;
using SportReserve_Reservations.Interfaces;
using SportReserve_Reservations.Validators;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Reservations_UnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class ValentineRaceReservationValidatorUnitTests
    {
        private readonly Mock<IReservationValidator> _mockReservationValidator;
        public ValentineRaceReservationValidatorUnitTests()
        {
            _mockReservationValidator = new Mock<IReservationValidator>();
        }

        [Fact]
        public void ValidateValentineRaceReservation_WhenCalled_ShouldInvokeValidateRaceOnce()
        {
            var raceValidator = new ValentineRaceReservationValidator(_mockReservationValidator.Object);

            var getRaceDto = new GetRaceDto();
            var getRaceTraceDto = new GetRaceTraceDto();
            var raceName = "Valentine Race with Heart";
            var userId = "1";
            var userIdFromToken = "1";
            raceValidator.ValidateValentineRaceReservation(getRaceDto, getRaceTraceDto, userId, userIdFromToken);

            _mockReservationValidator.Verify(x => x.ValidateRace(getRaceDto, getRaceTraceDto, raceName, userId, userIdFromToken), Times.Once);
        }
    }
}
