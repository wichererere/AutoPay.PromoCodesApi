namespace AutoPay.PromoCodesApi.UnitTests.Core.PromoCodeTests;

public class Constructor
{
  private readonly string _testName = "test name";
  private readonly string _testCode = "testCode";
  private readonly uint _testMaxPossibleDownloads = 10;

  [Fact]
  public void Constructor_Should_InitObject_WithGivenData()
  {
    var testPromoCode = new PromoCode(_testName, _testCode, _testMaxPossibleDownloads);
    
    Assert.Equal(_testName, testPromoCode.Name);
    Assert.Equal(_testCode, testPromoCode.Code);
    Assert.Equal(_testMaxPossibleDownloads, testPromoCode.MaxPossibleDownloads);
  }
}
