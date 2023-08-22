using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, GetEmployeesDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }
}
