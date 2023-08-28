using EmployeeManagement.Application.DTO;
using EmployeeManagement.Domain.Repository;

namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<List<EmployeeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}