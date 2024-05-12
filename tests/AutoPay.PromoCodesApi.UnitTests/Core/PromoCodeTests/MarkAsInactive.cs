namespace AutoPay.PromoCodesApi.UnitTests.Core.PromoCodeTests;

public class MarkAsInactive
{
  private readonly string _testName = "test name";
  private readonly string _testCode = "testCode";
  private readonly uint _testMaxPossibleDownloads = 10;
  
  [Fact]
  public void MarkAsInactive_Should_SetIsActiveToFalse()
  {
    var testPromoCode = new PromoCode(_testName, _testCode, _testMaxPossibleDownloads);
    
    Assert.True(testPromoCode.IsActive);
    
    testPromoCode.MarkAsInactive();
    
    Assert.False(testPromoCode.IsActive);
  }
}
