using AutoMapper;
using EmployeeManagement.Domain.Entities;

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
        public async Task<List<GetEmployeesDTO>> GetAllAsync()
        {
            List<Employee> employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<List<GetEmployeesDTO>>(employees);
        }
    }
}
