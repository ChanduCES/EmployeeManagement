using AutoMapper;
using EmployeeManagement.Application.DTO;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Application.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeesDTO>();
            CreateMap<Address, AddressDTO>();
        }
    }

}
