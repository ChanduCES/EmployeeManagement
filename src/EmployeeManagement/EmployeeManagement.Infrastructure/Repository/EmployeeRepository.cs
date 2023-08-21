using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repositories;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
