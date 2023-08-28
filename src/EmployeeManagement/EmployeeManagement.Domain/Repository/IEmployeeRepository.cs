using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
    }
}
