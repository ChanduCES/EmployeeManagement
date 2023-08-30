using AutoMapper;
using EmployeeManagement.Application.DTO;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repository;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map< List <Employee>, List <EmployeeDTO>>(employees);
        }
    }
}