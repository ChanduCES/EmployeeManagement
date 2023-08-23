using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.IntegrationTests.Helpers
{
    public static class TestDBSeeding
    {
        public static List<Address> FetchSeedingAddresses(List<Employee> employees)
        {
            return new List<Address>()
            {
                new Address() { EmployeeId = employees[0].Id, HouseNo = "Mann", Street = "123 street", City = "Bglore", State ="Karnataka", PostalCode = "690590"  },
                new Address() { EmployeeId = employees[1].Id, HouseNo = "45/253", Street = "church street", City = "Chennai", State ="Tamil Nadu", PostalCode = "622390"  },
                new Address() { EmployeeId = employees[2].Id, HouseNo = "AS2/25", Street = "2nd street", City = "Kochi", State ="Kerala", PostalCode = "686690"  },
            };
        }

        public static List<Employee> FetchSeedingEmployees()
        {
            return new List<Employee>()
            {
                new Employee() { FirstName = "Rahul", LastName = "Joseph", Email = "rj@gmail.com"},
                new Employee() { FirstName = "Chandu", LastName = "C", Email = "chan2@gmail.com"},
                new Employee() { FirstName = "Manuel", LastName = "Jose", Email = "Manu@gmail.com"}
            };
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
