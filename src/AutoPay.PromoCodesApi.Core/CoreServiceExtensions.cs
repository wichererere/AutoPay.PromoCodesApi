namespace AutoPay.PromoCodesApi.Core;

public static class CoreServiceExtensions
{
  public static IServiceCollection AddCoreServices(this IServiceCollection services, ILogger logger)
  {
    services.AddScoped<IDeletePromoCodeService, DeletePromoCodeService>();
    
    logger.LogInformation("{Project} services registered", "CoreTests");

    return services;
  }
}
