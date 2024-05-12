namespace AutoPay.PromoCodesApi.FunctionalTests.PromoCodes;

public class UpdatePromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnOk_WhenDataIsValid()
  {
    var promoCode = await CreatePromoCodeAsync("testCode");
    var route = UpdatePromoCodeRequest.BuildRoute(promoCode.Id);

    var request = new UpdatePromoCodeRequest { Id = promoCode.Id, Name = "newName" };
    var response = await HttpClient.PutAsJsonAsync(route, request);
    
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
  }
  
  [Fact]
  public async Task Should_ReturnNotFound_WhenPromoCodeNotExist()
  {
    var promoCodeId = 1000;
    var route = UpdatePromoCodeRequest.BuildRoute(promoCodeId);

    var request = new UpdatePromoCodeRequest { Id = promoCodeId, Name = "newName" };
    var response = await HttpClient.PutAsJsonAsync(route, request);
    
    Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
  }
  
  [Fact]
  public async Task Should_ReturnBadRequest_With_ValidationErrors_WhenDataIsInvalid()
  {
    var promoCode = await CreatePromoCodeAsync("testCode2");
    var route = UpdatePromoCodeRequest.BuildRoute(promoCode.Id);

    var request = new UpdatePromoCodeRequest { Id = promoCode.Id, Name = "n" };
    var response = await HttpClient.PutAsJsonAsync(route, request);
    
    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }
  
  private async Task<PromoCodeRecord> CreatePromoCodeAsync(string code)
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = code, MaxPossibleDownloads = 10 };
    var response = await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!;
  }
}
