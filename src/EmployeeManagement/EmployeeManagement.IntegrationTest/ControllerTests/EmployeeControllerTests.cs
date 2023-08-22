namespace EmployeeManagement.IntegrationTests.ControllerTests
{
    public class EmployeeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public EmployeeControllerTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task ShouldGetEmployeeList_WhenCalled_GetAllEmployeesAsync()
        {
            //Act
            var actual = await _httpClient.GetAsync($"{ApiRoutes.BaseUrl}/{ApiRoutes.Employee}");
            var result = await actual.Content.ReadFromJsonAsync<List<EmployeesDTO>>();

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
        }
    }
}
