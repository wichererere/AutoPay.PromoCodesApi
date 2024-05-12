namespace AutoPay.PromoCodesApi.IntegrationTests.PromoCodes;

public class DecreaseMaxPossibleDownloads(IntegrationTestsWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task DecreaseMaxPossibleDownloads_ShouldDecreaseBy1_WhenPromoCodeExist()
  {
    var createPromoCodeCommand = new CreatePromoCodeCommand("testName", "testCode", 10);
    var promoCodeResult = await Sender.Send(createPromoCodeCommand);

    var command = new DecreaseMaxPossibleDownloadsCommand(promoCodeResult.Value);
    var result = await Sender.Send(command);

    var promoCode = await DbContext.PromoCodes.FindAsync(promoCodeResult.Value);

    Assert.Equal(ResultStatus.Ok, result.Status);
    Assert.Equal(createPromoCodeCommand.MaxPossibleDownloads - 1, promoCode!.MaxPossibleDownloads);
  }
  
  [Fact]
  public async Task DecreaseMaxPossibleDownloads_ShouldReturnInvalid_WhenPromoCodeIsInvalid()
  {
    var createPromoCodeCommand = new CreatePromoCodeCommand("testName", "testCode2", 0);
    var promoCodeResult = await Sender.Send(createPromoCodeCommand);

    var command = new DecreaseMaxPossibleDownloadsCommand(promoCodeResult.Value);
    var result = await Sender.Send(command);

    Assert.Equal(ResultStatus.Invalid, result.Status);
    result.ValidationErrors.Should().OnlyContain(x => x.ErrorMessage == PromoCodeErrors.PossibleDownloadsEqualZero);
  }
}
