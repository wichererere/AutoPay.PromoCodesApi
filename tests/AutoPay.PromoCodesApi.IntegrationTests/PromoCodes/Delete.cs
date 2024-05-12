namespace AutoPay.PromoCodesApi.IntegrationTests.PromoCodes;

public class Delete(IntegrationTestsWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Delete_ShouldRemovePromoCode_FromDatabase()
  {
    var createPromoCodeCommand = new CreatePromoCodeCommand("testName", "testCode", 10);
    var promoCodeResult = await Sender.Send(createPromoCodeCommand);

    var command = new DeletePromoCodeCommand(promoCodeResult.Value);
    var result = await Sender.Send(command);

    var promoCode = await DbContext.PromoCodes.FindAsync(promoCodeResult.Value);

    Assert.Null(promoCode);
    Assert.Equal(ResultStatus.Ok, result.Status);
  }
}
