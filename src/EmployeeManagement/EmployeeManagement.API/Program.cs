using EmployeeManagement.API.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapHealthChecks($"{ApiRoutes.BaseUrl}/{ApiRoutes.HealthCheckAPI}");

app.Run();

public partial class Program { }
