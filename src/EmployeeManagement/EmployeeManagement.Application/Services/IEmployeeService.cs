﻿using EmployeeManagement.Application.DTO;

namespace EmployeeManagement.Application.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeesDTO>> GetAllAsync();
    }
}
