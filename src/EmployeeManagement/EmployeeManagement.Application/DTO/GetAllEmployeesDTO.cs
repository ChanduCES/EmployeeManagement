﻿namespace EmployeeManagement.Application.DTO
{
    public class GetAllEmployeesDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressDTO Address { get; set; }
    }
}