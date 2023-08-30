using Bogus;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.IntegrationTests.Helpers
{
    public static class TestDBSampleData
    {
        private static List<Employee> _employees = GenerateEmployees();
        private static List<Address> _addresses;

        private static List<Address> GenerateAddresses(List<Employee> employees)
        {
            List<Address> addresses = new List<Address>();
            foreach (Employee employee in employees)
            {
                addresses.Add(new Faker<Address>()
                                .RuleFor(x => x.Id, f => Guid.NewGuid())
                                .RuleFor(x => x.EmployeeId, f => employee.Id)
                                .RuleFor(x => x.HouseNo, f => f.Address.BuildingNumber())
                                .RuleFor(x => x.Street, f => f.Address.StreetAddress())
                                .RuleFor(x => x.City, f => f.Address.City())
                                .RuleFor(x => x.State, f => f.Address.State())
                                .RuleFor(x => x.PostalCode, f => f.Address.ZipCode()));
            }
            
            return addresses;
        }

        private static List<Employee> GenerateEmployees()
        {
            var employees = new Faker<Employee>()
                                .RuleFor(x => x.Id, f => Guid.NewGuid())
                                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                                .RuleFor(x => x.LastName, f => f.Person.LastName)
                                .RuleFor(x => x.Email, f => f.Person.Email)
                                .GenerateBetween(0,10);
            _addresses = GenerateAddresses(employees);
            return employees;
        }

        public static List<Employee> GetEmployees() 
        {
            return _employees;
        }

        public static async void InitializeDbForTests(CustomWebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeDBContext>();

            //Adding employee seed data
            dbContext.Employees.RemoveRange(dbContext.Employees);
            dbContext.Employees.AddRange(_employees);
            dbContext.SaveChanges();

            //Adding addresses seed data
            dbContext.Addresses.RemoveRange(dbContext.Addresses);
            var emp = await dbContext.Employees.ToListAsync();
            dbContext.Addresses.AddRange(_addresses);
            dbContext.SaveChanges();

        }
    }
}
