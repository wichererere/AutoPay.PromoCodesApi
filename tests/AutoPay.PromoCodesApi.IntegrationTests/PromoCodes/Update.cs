using AutoPay.PromoCodesApi.UseCases.PromoCodes.Update;

namespace AutoPay.PromoCodesApi.IntegrationTests.PromoCodes;

public class Update(IntegrationTestsWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Update_Should_UpdatePromoCode()
  {
    var command = new CreatePromoCodeCommand("testName", "testCode", 10);
    var result = await Sender.Send(command);

    var updateCommand = new UpdatePromoCodeCommand(result.Value, "newName");
    await Sender.Send(updateCommand);
    
    var promoCode = await DbContext.PromoCodes.FindAsync(result.Value);
    
    Assert.NotNull(promoCode);
    Assert.NotEqual(promoCode.Name, command.Name);
    Assert.Equal(promoCode.Code, command.Code);
  }
}
