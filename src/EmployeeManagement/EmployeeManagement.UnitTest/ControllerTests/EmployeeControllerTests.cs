﻿namespace EmployeeManagement.UnitTests.ControllerTests
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeService> _employeeServiceMock;
        private readonly Fixture _fixture;

        public EmployeeControllerTests()
        {
            _fixture = new Fixture();
            _employeeServiceMock = new Mock<IEmployeeService>();
        }
        private EmployeeController CreateEmployeeController()
        {
            return new EmployeeController();
        }

        [Fact]
        public async Task ShouldGetEmployeeList_WhenGetAllEmployees_IsCalled()
        {
            //Arrange
            var employeeController = CreateEmployeeController();
            List<EmployeeDTO> employees = _fixture.CreateMany<EmployeeDTO>().ToList();
            _employeeServiceMock.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);

            //Act
            var result = await employeeController.GetAllAsync();

            //Assert
            var employeeResult = result.Result as OkObjectResult;
            employeeResult?.StatusCode.Should().Be(StatusCodes.Status200OK);
            employeeResult?.Value.Should().BeEquivalentTo(employees);
        }
    }
}
