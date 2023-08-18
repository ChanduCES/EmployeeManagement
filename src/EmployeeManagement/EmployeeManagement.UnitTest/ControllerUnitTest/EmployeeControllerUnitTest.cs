namespace EmployeeManagement.UnitTest.ControllerUnitTest
{
    public class EmployeeControllerUnitTest
    {
        private readonly Mock<IEmployeeService> _employeeServiceMock;
        private readonly Fixture _fixture;

        public EmployeeControllerUnitTest()
        {
            _fixture = new Fixture();
            _employeeServiceMock = new Mock<IEmployeeService>();
        }
        private EmployeeController CreateEmployeeController()
        {
            return new EmployeeController();
        }

        [Fact]
        public async Task ShouldGetEmployeeList_WhenGetAllAsync_IsCalled()
        {
            //Arrange
            var employeeController = CreateEmployeeController();
            List<GetAllEmployeesDTO> employees = _fixture.CreateMany<GetAllEmployeesDTO>().ToList();
            _employeeServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);

            //Act
            var result = await employeeController.GetAllAsync();

            //Assert
            var employeeResult = result.Result as OkObjectResult;
            employeeResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
            employeeResult?.Value.Should().BeEquivalentTo(employees);
        }
    }
}
