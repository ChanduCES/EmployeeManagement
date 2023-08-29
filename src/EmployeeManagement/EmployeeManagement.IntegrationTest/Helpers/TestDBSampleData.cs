using Bogus;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.IntegrationTests.Helpers
{
    public static class TestDBSampleData
    {
        public static List<Address> FetchSeedingAddresses(List<Employee> employees)
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

        public static List<Employee> FetchSeedingEmployees()
        {
            var employees = new Faker<Employee>()
                                .RuleFor(x => x.Id, f => Guid.NewGuid())
                                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                                .RuleFor(x => x.LastName, f => f.Person.LastName)
                                .RuleFor(x => x.Email, f => f.Person.Email)
                                .GenerateBetween(0,10);
            return employees;
        }

        public static async void InitializeDbForTests(CustomWebApplicationFactory<Program> factory)
        {
            using var scope = factory.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<EmployeeDBContext>();

            //Adding employee seed data
            dbContext.Employees.RemoveRange(dbContext.Employees);
            var employees = FetchSeedingEmployees();
            dbContext.Employees.AddRange(employees);
            dbContext.SaveChanges();

            //Adding addresses seed data
            dbContext.Addresses.RemoveRange(dbContext.Addresses);
            var emp = await dbContext.Employees.ToListAsync();
            var addresses = FetchSeedingAddresses(emp);
            dbContext.Addresses.AddRange(addresses);
            dbContext.SaveChanges();

        }
    }
}
