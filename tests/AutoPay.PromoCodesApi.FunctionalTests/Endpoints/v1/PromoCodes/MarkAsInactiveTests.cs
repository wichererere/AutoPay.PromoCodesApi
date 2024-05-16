using AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

namespace AutoPay.PromoCodesApi.FunctionalTests.Endpoints.v1.PromoCodes;

public class MarkAsInactiveTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnNoContent_WhenPromoCodeMarkedAsInactive()
  {
    var promoCode = await CreatePromoCodeAsync();
    var request = new MarkAsInactiveRequest { Id = promoCode.Id };

    var result = await HttpClient.PutAsJsonAsync(GetRoute(promoCode.Id), request);

    Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var promoCodeId = 1000;
    var request = new MarkAsInactiveRequest { Id = promoCodeId };
    
    var response = await HttpClient.PutAsJsonAsync(GetRoute(promoCodeId), request);

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }
  
  private async Task<PromoCodeRecord> CreatePromoCodeAsync()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = 10 };
    var response = await HttpClient.PostAsJsonAsync($"{ EndpointSettings.Version }{ CreatePromoCodeRequest.Route }", request);
    
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!;
  }
  
  private static string GetRoute(int promoCodeId)
  {
    return $"{ EndpointSettings.Version }{ MarkAsInactiveRequest.BuildRoute(promoCodeId) }";
  }
}
