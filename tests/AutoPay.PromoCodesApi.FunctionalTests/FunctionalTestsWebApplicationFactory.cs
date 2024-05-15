using DotNet.Testcontainers.Builders;

namespace AutoPay.PromoCodesApi.FunctionalTests;

public class FunctionalTestsWebApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
  private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
    .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
    .WithPassword("P@ssw0rd")
    .WithCleanUp(true)
    .Build();
  
  public async Task InitializeAsync()
  {
    await _dbContainer.StartAsync();
    using var scope = Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.GetConnectionString();
    await dbContext.Database.MigrateAsync();
  }

  public new Task DisposeAsync() => _dbContainer.DisposeAsync().AsTask();
  
  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureTestServices(services =>
    {
      services.RemoveAll(typeof(DbContextOptions<AppDbContext>));

      services.AddDbContext<AppDbContext>(options => 
        options.UseSqlServer(_dbContainer.GetConnectionString(),
          x => x.MigrationsAssembly(Provider.SqlServer.Assembly)
        ));
    });
  }
}
