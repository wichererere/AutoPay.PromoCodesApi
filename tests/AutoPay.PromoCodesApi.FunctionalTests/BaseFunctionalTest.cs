namespace AutoPay.PromoCodesApi.FunctionalTests;

public abstract class BaseFunctionalTest(FunctionalTestsWebApplicationFactory factory) : IClassFixture<FunctionalTestsWebApplicationFactory>
{
  protected HttpClient HttpClient { get; init; } = factory.CreateClient();
}
