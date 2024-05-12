namespace AutoPay.PromoCodesApi.IntegrationTests.PromoCodes;

public class Get(IntegrationTestsWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Get_ShouldReturnPromoCode_WhenPromoCodeIsFound()
  {
    var command = new CreatePromoCodeCommand("testName", "testCode", 10);
    var result = await Sender.Send(command);

    var query = new GetPromoCodeQuery(result.Value);
    var queryResult = await Sender.Send(query);
    
    Assert.NotNull(queryResult.Value);
    
    Assert.Equal(command.Name, queryResult.Value.Name);
    Assert.Equal(command.Code, queryResult.Value.Code);
    Assert.Equal(command.MaxPossibleDownloads, queryResult.Value.MaxPossibleDownloads);
    Assert.True(queryResult.Value.IsActive);
  }
}
