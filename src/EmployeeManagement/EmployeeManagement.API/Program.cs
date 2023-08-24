using EmployeeManagement.API.Constants;

public partial class Program {
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddHealthChecks();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var app = builder.Build();

        app.MapHealthChecks($"{ApiRoutes.BaseUrl}/{ApiRoutes.HealthCheckAPI}");
        app.UseSwagger();

        app.Run();
    }
}

public partial class Program { }
