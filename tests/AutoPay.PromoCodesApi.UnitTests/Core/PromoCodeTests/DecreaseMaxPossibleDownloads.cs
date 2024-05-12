namespace AutoPay.PromoCodesApi.UnitTests.Core.PromoCodeTests;

public class DecreaseMaxPossibleDownloads
{
  private readonly string _testName = "test name";
  private readonly string _testCode = "testCode";
  private readonly uint _testMaxPossibleDownloads = 10;

  [Fact]
  public void DecreaseMaxPossibleDownloads_Should_DecreaseByOne_WhenValueIsPositive()
  {
    var testPromoCode = new PromoCode(_testName, _testCode, _testMaxPossibleDownloads);
    testPromoCode.DecreaseMaxPossibleDownloads();
    
    Assert.Equal(testPromoCode.MaxPossibleDownloads, _testMaxPossibleDownloads - 1);
  }
  
  [Fact]
  public void DecreaseMaxPossibleDownloads_Should_ThrowArgumentException_WhenValueIsBelowZero()
  {
    var testPromoCode = new PromoCode(_testName, _testCode, 0);
    Assert.Throws<ArgumentException>(() => testPromoCode.DecreaseMaxPossibleDownloads());
  }
}
