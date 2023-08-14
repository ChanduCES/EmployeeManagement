using System.Net.Http;

namespace EmployeeManagement.IntegrationTest
{
    public class SwaggerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public SwaggerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task SwaggerAPI_WhenCalled_ShouldReturnStatus200Ok()
        {
            //Act
            var actual = await _httpClient.GetAsync(ApiRoutes.SwaggerEndpoint);

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
