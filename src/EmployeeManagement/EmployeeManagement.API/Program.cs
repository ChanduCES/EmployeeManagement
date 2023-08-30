using EmployeeManagement.Application.Profiles;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Repository;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

public partial class Program {
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("EmployeeConnString");
        builder.Services.AddDbContext<EmployeeDBContext>(x => x.UseSqlServer(connectionString));
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IEmployeeService, EmployeeService>();

        builder.Services.AddAutoMapper(typeof(EmployeeProfile));
        builder.Services.AddHealthChecks();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapHealthChecks($"{ApiRoutes.BaseUrl}/{ApiRoutes.HealthCheckAPI}");
        app.UseSwagger();
        app.MapControllers();

        app.Run();
    }
}

public partial class Program { }
