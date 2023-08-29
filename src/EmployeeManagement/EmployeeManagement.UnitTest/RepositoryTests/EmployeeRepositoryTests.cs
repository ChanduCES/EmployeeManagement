using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.UnitTests.RepositoryTests
{
    public class EmployeeRepositoryTests
    {
        private readonly Fixture _fixture;
        private readonly EmployeeDBContext _employeeContext;
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeRepositoryTests()
        {
            _fixture = new Fixture();
            var options = new DbContextOptionsBuilder<EmployeeDBContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _employeeContext = new EmployeeDBContext(options);
            _employeeContext.Database.EnsureCreated();
            _employeeRepository = new EmployeeRepository(_employeeContext);
        }

        [Fact]
        public async Task ShouldReturnEmployees_WhenCalled_GetAllAsync()
        {
            //Arrange
            var employees = _fixture.CreateMany<Employee>();
            _employeeContext.Employees.AddRange(employees);
            _employeeContext.SaveChanges();

            //Act
            var result = await _employeeRepository.GetAllAsync();

            //Assert
            result.Should().BeEquivalentTo(employees);
        }
    }
}
