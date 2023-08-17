namespace EmployeeManagement.IntegrationTest.ControllerTests
{
    public class EmployeeControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public EmployeeControllerTest(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task ShouldGetEmployeeList_WhenCalled_GetAllEmployeesAsync()
        {
            //Act
            var actual = await _httpClient.GetAsync($"{ApiRoutes.BaseUrl}/{ApiRoutes.Employee}");

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
