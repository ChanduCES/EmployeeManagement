﻿namespace EmployeeManagement.Application.DTO
{
    public record EmployeeDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AddressDTO Address { get; set; }
    }
}
