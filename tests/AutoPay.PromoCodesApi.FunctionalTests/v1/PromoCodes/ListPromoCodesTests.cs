using AutoPay.PromoCodesApi.Web.v1.PromoCodes;

namespace AutoPay.PromoCodesApi.FunctionalTests.v1.PromoCodes;

public class ListPromoCodesTests(FunctionalTestsWebApplicationFactory factory) : BaseFunctionalTest(factory)
{
  [Fact]
  public async Task Should_ContainsAddedElement()
  {
    var response = await CreatePromoCodeAsync();
    var promoCodes = await HttpClient.GetAndDeserializeAsync<PromoCodeListResponse>($"{ EndpointSettings.Version }{ ListRequest.Route }");

    Assert.NotEmpty(promoCodes.PromoCodes);
    Assert.Contains(response, promoCodes.PromoCodes);
  }
  
  private async Task<PromoCodeRecord> CreatePromoCodeAsync()
  {
    var request = new CreatePromoCodeRequest { Name = "TestName", Code = "ValidCode", MaxPossibleDownloads = 10};
    var response = await HttpClient.PostAsJsonAsync($"{ EndpointSettings.Version }{ CreatePromoCodeRequest.Route }", request);
    
    return (await response.Content.ReadFromJsonAsync<PromoCodeRecord>())!;
  }
}
