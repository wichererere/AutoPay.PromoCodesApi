namespace AutoPay.PromoCodesApi.FunctionalTests.PromoCodes;

public class MarkAsInactiveTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnNoContent_WhenPromoCodeMarkedAsInactive()
  {
    var promoCode = await CreatePromoCodeAsync();
    var route = MarkAsInactiveRequest.BuildRoute(promoCode.Id);
    
    var request = new MarkAsInactiveRequest { Id = promoCode.Id };

    var result = await HttpClient.PutAsJsonAsync(route, request);

    Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var promoCodeId = 1000;
    
    var route = MarkAsInactiveRequest.BuildRoute(promoCodeId);
    var request = new MarkAsInactiveRequest { Id = promoCodeId };
    var response = await HttpClient.PutAsJsonAsync(route, request);

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }
  
  private async Task<PromoCodeRecord> CreatePromoCodeAsync()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = 10 };
    var response = await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!;
  }
}
