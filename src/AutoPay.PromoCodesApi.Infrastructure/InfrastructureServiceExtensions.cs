namespace AutoPay.PromoCodesApi.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration config,
        ILogger logger)
    {
      RegisterDependencies(services);
      RegisterEF(services, config);
      
      logger.LogInformation("{Project} services registered", "Infrastructure");

      return services;
    }
  
    private static void RegisterDependencies(IServiceCollection services)
    {
      services.AddScoped<IListPromoCodesQueryService, ListPromoCodesQueryService>();
    }

    private static void RegisterEF(IServiceCollection services, IConfiguration config)
    {
      // string? connectionString = config.GetConnectionString("DefaultConnection");
      // Guard.Against.Null(connectionString);
      
      var provider = config.GetValue("Provider", "SqlServer");

      services.AddDbContext<AppDbContext>(
        options =>
        {
          if (provider == Provider.Sqlite.Name)
          {
            options.UseSqlite(
              config.GetConnectionString(Provider.Sqlite.Name)!,
              x => x.MigrationsAssembly(Provider.Sqlite.Assembly)
            );
          }

          if (provider == Provider.SqlServer.Name)
          {
            options.UseSqlServer(
              config.GetConnectionString(Provider.SqlServer.Name)!,
              x => x.MigrationsAssembly(Provider.SqlServer.Assembly)
            );
          }
        });

      services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
      services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    }
}
