using AutoPay.PromoCodesApi.Web.v1.PromoCodes;

namespace AutoPay.PromoCodesApi.FunctionalTests.v1.PromoCodes;

public class UpdatePromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnOk_WhenDataIsValid()
  {
    var promoCode = await CreatePromoCodeAsync("testCode");
    var request = new UpdatePromoCodeRequest { Id = promoCode.Id, Name = "newName" };
    
    var response = await HttpClient.PutAsJsonAsync(GetRoute(promoCode.Id), request);
    
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var promoCodeId = 1000;
    var request = new UpdatePromoCodeRequest { Id = promoCodeId, Name = "newName" };
    
    var response = await HttpClient.PutAsJsonAsync(GetRoute(promoCodeId), request);
    
    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }
  
  [Fact]
  public async Task Should_ReturnBadRequest_With_ValidationErrors_WhenDataIsInvalid()
  {
    var promoCode = await CreatePromoCodeAsync("testCode2");
    var request = new UpdatePromoCodeRequest { Id = promoCode.Id, Name = "n" };
    
    var response = await HttpClient.PutAsJsonAsync(GetRoute(promoCode.Id), request);
    
    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }
  
  private async Task<PromoCodeRecord> CreatePromoCodeAsync(string code)
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = code, MaxPossibleDownloads = 10 };
    var response = await HttpClient.PostAsJsonAsync($"{ EndpointSettings.Version }{ CreatePromoCodeRequest.Route }", request);
    
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!;
  }
  
  private static string GetRoute(int promoCodeId)
  {
    return $"{ EndpointSettings.Version }{ UpdatePromoCodeRequest.BuildRoute(promoCodeId) }";
  }
}
