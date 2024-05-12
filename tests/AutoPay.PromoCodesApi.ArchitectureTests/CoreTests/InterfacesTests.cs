namespace AutoPay.PromoCodesApi.ArchitectureTests.CoreTests;

public class InterfacesTests : CoreTestsBase
{
  [Fact]
  public void Interfaces_Should_StartWithI()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .AreInterfaces()
      .Should()
      .HaveNameStartingWith("I")
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
}
