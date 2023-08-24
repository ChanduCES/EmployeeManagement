using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.IntegrationTests.Helpers
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        public IConfiguration Configuration { get; set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.IntegrationTests.json").Build();
                config.AddConfiguration(Configuration);
            });

            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<EmployeeDBContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddDbContext<EmployeeDBContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("EmployeeConnString"));
                });
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<EmployeeDBContext>())
                {
                    appContext.Database.EnsureCreated();
                }
            });

            builder.UseEnvironment("IntegrationTests");
        }
    }
}
