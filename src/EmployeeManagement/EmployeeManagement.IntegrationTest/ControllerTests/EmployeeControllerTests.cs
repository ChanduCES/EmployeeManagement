using AutoMapper;
using EmployeeManagement.Application.Profiles;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.IntegrationTests.Helpers;

namespace EmployeeManagement.IntegrationTests.ControllerTests
{
    public class EmployeeControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private readonly CustomWebApplicationFactory<Program> _appFactory;
        private readonly IMapper _mapper;

        public EmployeeControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _appFactory = factory;
           _httpClient = _appFactory.CreateClient();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<EmployeeProfile>()).CreateMapper();
        }

        [Fact]
        public async Task ShouldGetEmployeeList_WhenCalled_GetAllEmployeesAsync()
        {
            //Arrange
            TestDBSampleData.InitializeDbForTests(_appFactory);
            var employeeDto = _mapper.Map<List<EmployeesDTO>>(TestDBSampleData.FetchSeedingEmployees());

            //Act
            var actual = await _httpClient.GetAsync($"{ApiRoutes.BaseUrl}/{ApiRoutes.Employee}");
            var result = await actual.Content.ReadFromJsonAsync<List<EmployeesDTO>>();

            //Assert
            actual.StatusCode.Should().Be(HttpStatusCode.OK);
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(employeeDto, x => x.Excluding(y => y.Id));
        }
    }
}
