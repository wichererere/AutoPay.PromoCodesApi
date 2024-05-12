using AutoPay.PromoCodesApi.UseCases.PromoCodes.MarkAsInactive;

namespace AutoPay.PromoCodesApi.IntegrationTests.PromoCodes;

public class MarkAsInactive(IntegrationTestsWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task MarkAsInactive_Should_DeactivatePromoCode()
  {
    var createPromoCodeCommand = new CreatePromoCodeCommand("testName", "testCode", 10);
    var promoCodeResult = await Sender.Send(createPromoCodeCommand);

    var command = new MarkAsInactiveCommand(promoCodeResult.Value);
    var result = await Sender.Send(command);

    var promoCode = await DbContext.PromoCodes.FindAsync(promoCodeResult.Value);

    Assert.Equal(ResultStatus.Ok, result.Status);
    Assert.False(promoCode!.IsActive);
  }
}
