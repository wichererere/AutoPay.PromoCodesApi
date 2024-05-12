namespace AutoPay.PromoCodesApi.FunctionalTests.PromoCodes;

public class CreatePromoCodeTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ReturnBadRequest_WhenDataIsMissing()
  {
    var request = new CreatePromoCodeRequest();
    var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
    
    await HttpClient.PostAndEnsureBadRequestAsync("/PromoCodes", content);
  }
  
  [Fact]
  public async Task Should_ReturnOk_WhenDataIsValid()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = 10};

    var response = await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
  }

  [Fact]
  public async Task Should_ReturnBadRequest_WhenDuplicatedCodeInserted()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "TestCode", MaxPossibleDownloads = 10};

    await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    var response = await HttpClient.PostAsJsonAsync("/PromoCodes", request);
    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
  }
}
