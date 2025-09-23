using Moq;
using SportReserve_Reservations.Factories;

namespace SportReserve_Reservations_UnitTests.Factories
{
    [Trait("Category", "Unit")]
    public class HttpClientFactoryUnitTests
    {
        private readonly Mock<IHttpClientFactory> _mockClientFactory;
        public HttpClientFactoryUnitTests()
        {
            _mockClientFactory = new Mock<IHttpClientFactory>();
        }

        [Fact]
        public void CreateClient_WhenCalled_ShouldInvokeCreateClientOnIHttpClientFactoryOnce()
        {
            var client = new HttpClientFactory(_mockClientFactory.Object);

            var serviceName = "UserService";

            client.CreateClient(serviceName);

            _mockClientFactory.Verify(x => x.CreateClient(serviceName), Times.Once());
        }
    }
}
