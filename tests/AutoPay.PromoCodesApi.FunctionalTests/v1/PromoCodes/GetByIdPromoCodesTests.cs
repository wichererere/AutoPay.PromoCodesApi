using AutoPay.PromoCodesApi.Web.v1.PromoCodes;

namespace AutoPay.PromoCodesApi.FunctionalTests.v1.PromoCodes;

public class GetByIdPromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnOk_And_User_WhenPromoCodeExist()
  {
    var promoCodeId = await CreatePromoCodeAsync();
    var promoCode = await HttpClient.GetFromJsonAsync<PromoCodeRecord>(GetRoute(promoCodeId));

    promoCode.Should().NotBeNull();
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var route = GetPromoCodeByIdRequest.BuildRoute(1000);
    
    var response = await HttpClient.GetAsync(GetRoute(1000));

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }
  
  private async Task<int> CreatePromoCodeAsync(uint maxPossibleDownloads = 10)
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = maxPossibleDownloads};

    var response = await HttpClient.PostAsJsonAsync($"{ EndpointSettings.Version }{ CreatePromoCodeRequest.Route }", request);
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!.Id;
  }
  
  private static string GetRoute(int promoCodeId)
  {
    return $"{ EndpointSettings.Version }{ GetPromoCodeByIdRequest.BuildRoute(promoCodeId) }";
  }
}
