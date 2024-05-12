namespace AutoPay.PromoCodesApi.IntegrationTests.PromoCodes;

public class Create(IntegrationTestsWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
  [Fact]
  public async Task Create_ShouldAddNewPromoCode_WhenDataIsValid()
  {
    var command = new CreatePromoCodeCommand("testName", "testCode", 10);
    var result = await Sender.Send(command);
    var promoCode = await DbContext.PromoCodes.FindAsync(result.Value);

    Assert.NotNull(promoCode);
    
    Assert.Equal(command.Name, promoCode.Name);
    Assert.Equal(command.Code, promoCode.Code);
    Assert.Equal(command.MaxPossibleDownloads, promoCode.MaxPossibleDownloads);
    Assert.True(promoCode.IsActive);
  }
  
  [Fact]
  public async Task Create_ShouldReturnValidationError_WhenCodeIsDuplicated()
  {
    var command = new CreatePromoCodeCommand("testName", "testCode2", 10);
    await Sender.Send(command);
    
    var result = await Sender.Send(command);
    
    Assert.False(result.IsSuccess);
    Assert.Equal(ResultStatus.Invalid, result.Status);
    result.ValidationErrors.Should().OnlyContain(x => x.ErrorMessage == PromoCodeErrors.CodeNotUnique);
  }
}
