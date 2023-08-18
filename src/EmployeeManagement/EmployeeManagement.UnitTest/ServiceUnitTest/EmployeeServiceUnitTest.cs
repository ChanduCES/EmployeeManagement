using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.UnitTest.ServiceUnitTest
{
    public  class EmployeeServiceUnitTest
    {
        private readonly Fixture _fixture;
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _employeeRepository;

        public EmployeeServiceUnitTest()
        {
            _fixture = new Fixture();
            _employeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService();
        }

        [Fact]
        public async Task ShouldGetAllEmployees_WhenCalled_GetAllAsync()
        {
            //Arrange
            List<Employee> employees = _fixture.CreateMany<Employee>().ToList();
            _employeeRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);

            //Act
            var actual = await _employeeService.GetAllAsync();

            //Assert
            actual.Should().BeEquivalentTo(employees);
            actual.Count().Should().Be(employees.Count());
        }
    }
}
