namespace AutoPay.PromoCodesApi.FunctionalTests.PromoCodes;

public class GetByIdPromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnOk_And_User_WhenPromoCodeExist()
  {
    var promoCodeId = await CreatePromoCodeAsync();
    var route = GetPromoCodeByIdRequest.BuildRoute(promoCodeId);
    
    var promoCode = await HttpClient.GetFromJsonAsync<PromoCodeRecord>(route);

    promoCode.Should().NotBeNull();
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var route = GetPromoCodeByIdRequest.BuildRoute(1000);
    
    var response = await HttpClient.GetAsync(route);

    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }
  
  private async Task<int> CreatePromoCodeAsync(uint maxPossibleDownloads = 10)
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = maxPossibleDownloads};

    var response = await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!.Id;
  }
}
