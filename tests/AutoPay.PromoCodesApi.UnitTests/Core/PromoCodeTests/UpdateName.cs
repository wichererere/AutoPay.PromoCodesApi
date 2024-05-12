namespace AutoPay.PromoCodesApi.UnitTests.Core.PromoCodeTests;

public class UpdateName
{
  private readonly string _testName = "test name";
  private readonly string _testCode = "testCode";
  private readonly uint _testMaxPossibleDownloads = 10;

  [Fact]
  public void UpdateName_Should_SetNewName_WhenValueIsValid()
  {
    var testPromoCode = new PromoCode(_testName, _testCode, _testMaxPossibleDownloads);
    var newName = "newName";
    testPromoCode.UpdateName(newName);
    
    Assert.Equal(testPromoCode.Name, newName);
  }
  
  [Fact]
  public void UpdateName_Should_ThrowArgumentException_WhenValueIsEmpty()
  {
    var testPromoCode = new PromoCode(_testName, _testCode, _testMaxPossibleDownloads);
    Assert.Throws<ArgumentException>(() => testPromoCode.UpdateName(""));
  }
}
