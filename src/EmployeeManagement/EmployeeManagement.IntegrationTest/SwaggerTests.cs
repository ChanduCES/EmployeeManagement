using EmployeeManagement.IntegrationTest.Constants;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

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
            var actual = await _httpClient.GetAsync(TestConstants.SwaggerEndpoint);
            var result = await actual.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<JObject>(result);
            string title = jsonObject[TestConstants.InfoJObject][TestConstants.TitleJObject].ToString();

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
            title.Should().Be(TestConstants.EmployeeManagementAPI);
        }
    }
}
