using AutoPay.PromoCodesApi.Web.v1.PromoCodes;

namespace AutoPay.PromoCodesApi.FunctionalTests.v1.PromoCodes;

public class DeletePromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnNoContent_WhenPromoCodeDeleted()
  {
    var promoCodeId = await CreatePromoCodeAsync();
    await HttpClient.DeleteAndEnsureNoContentAsync(GetRoute(promoCodeId));
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    await HttpClient.DeleteAndEnsureNotFoundAsync(GetRoute(1000));
  }
  
  private async Task<int> CreatePromoCodeAsync()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = 10};

    var response = await HttpClient.PostAsJsonAsync($"{ EndpointSettings.Version }{ CreatePromoCodeRequest.Route }", request);
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!.Id;
  }
  
  private static string GetRoute(int promoCodeId)
  {
    return $"{ EndpointSettings.Version }{ DeletePromoCodeRequest.BuildRoute(promoCodeId) }";
  }
}
