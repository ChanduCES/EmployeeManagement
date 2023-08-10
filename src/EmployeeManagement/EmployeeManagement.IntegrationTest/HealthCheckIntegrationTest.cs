using EmployeeManagement.API.Constants;
using EmployeeManagement.IntegrationTest.Constants;

namespace EmployeeManagement.IntegrationTest
{
    public class HealthCheckIntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public HealthCheckIntegrationTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task HealthCheckAPI_WhenCalled_ShouldReturnStatus200Ok()
        {
            //Act
            var actual = await _httpClient.GetAsync($"{ApiRoutes.BaseUrl}/{TestConstants.HealthCheckAPI}");

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
