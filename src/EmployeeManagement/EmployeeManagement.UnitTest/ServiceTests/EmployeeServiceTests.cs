﻿using AutoMapper;
using EmployeeManagement.Application.Profiles;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repository;

namespace EmployeeManagement.UnitTest.ServiceUnitTest
{
    public class EmployeeServiceUnitTest
    {
        private readonly Fixture _fixture;
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeServiceUnitTest()
        {
            _fixture = new Fixture();
            _employeeRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_employeeRepository.Object);
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new EmployeeProfile()));
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public async Task ShouldGetEmployees_WhenCalled_GetAllAsync()
        {
            //Arrange
            List<Employee> employees = _fixture.CreateMany<Employee>().ToList();
            _employeeRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(employees);
            List<EmployeeDTO> employeeDto = _mapper.Map<List<EmployeeDTO>>(employees);

            //Act
            var actual = await _employeeService.GetAllAsync();

            //Assert
            actual.Should().BeEquivalentTo(employeeDto);
            actual.Count().Should().Be(employeeDto.Count());
        }
    }
}