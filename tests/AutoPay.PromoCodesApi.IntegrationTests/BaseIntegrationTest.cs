namespace AutoPay.PromoCodesApi.IntegrationTests;

public abstract class BaseIntegrationTest : IClassFixture<IntegrationTestsWebApplicationFactory>
{
  protected readonly ISender Sender;
  protected readonly AppDbContext DbContext;

  protected BaseIntegrationTest(IntegrationTestsWebApplicationFactory factory)
  {
    var scope = factory.Services.CreateScope();
    Sender = scope.ServiceProvider.GetRequiredService<ISender>();
    DbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  }
}
