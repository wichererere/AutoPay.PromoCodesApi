namespace AutoPay.PromoCodesApi.FunctionalTests.PromoCodes;

public class DeletePromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnNoContent_WhenPromoCodeDeleted()
  {
    var promoCodeId = await CreatePromoCodeAsync();
    var route = GetPromoCodeByIdRequest.BuildRoute(promoCodeId);
    
    await HttpClient.DeleteAndEnsureNoContentAsync(route);
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var route = GetPromoCodeByIdRequest.BuildRoute(1000);
    await HttpClient.DeleteAndEnsureNotFoundAsync(route);
  }
  
  private async Task<int> CreatePromoCodeAsync()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = 10};

    var response = await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!.Id;
  }
}
