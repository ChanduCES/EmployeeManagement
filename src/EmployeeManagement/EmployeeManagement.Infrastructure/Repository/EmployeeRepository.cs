using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Repository;
using EmployeeManagement.Infrastructure.Data;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDBContext _context;

        public EmployeeRepository(EmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}