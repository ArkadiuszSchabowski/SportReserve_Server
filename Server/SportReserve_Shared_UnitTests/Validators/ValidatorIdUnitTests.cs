using FluentAssertions;
using SportReserve_Shared.Exceptions;
using SportReserveServer.Validators;

namespace SportReserveServerUnitTests.Validators
{
    [Trait("Category", "Unit")]
    public class ValidatorIdUnitTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(20)]
        [InlineData(10000)]
        public void ValidateId_WithValidId_DoesNotThrowException(int id)
        {
            var validatorId = new ValidatorId();

            var action = () => validatorId.ValidateId(id);

            action.Should().NotThrow();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-30)]
        [InlineData(-99)]
        public void ValidateId_WhenIdEqualOrLessThanZero_ReturnsBadRequestException(int id)
        {
            var validatorId = new ValidatorId();

            var action = () => validatorId.ValidateId(id);

            action.Should().Throw<BadRequestException>().WithMessage("Id value should be greater than 0.");
        }
    }
}
