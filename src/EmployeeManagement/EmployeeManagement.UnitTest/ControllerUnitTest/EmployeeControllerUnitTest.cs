namespace EmployeeManagement.UnitTest.ControllerUnitTest
{
    public class EmployeeControllerUnitTest
    {
        private EmployeeController CreateEmployeeController()
        {
            return new EmployeeController();
        }

        [Fact]
        public async Task ShouldGetEmployeeList_WhenGetAllEmployees_IsCalled()
        {
            //Arrange
            var employeeController = CreateEmployeeController();

            //Act
            var result = await employeeController.GetAllAsync();

            //Assert
            var employeeResult = result.Result as OkObjectResult;
            employeeResult?.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}
