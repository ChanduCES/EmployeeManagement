namespace EmployeeManagement.IntegrationTests
{
    public class HealthCheckTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public HealthCheckTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task HealthCheckAPI_WhenCalled_ShouldReturnStatus200Ok()
        {
            //Act
            var actual = await _httpClient.GetAsync($"{ApiRoutes.BaseUrl}/{ApiRoutes.HealthCheckAPI}");

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
