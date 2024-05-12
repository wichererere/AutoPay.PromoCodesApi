namespace AutoPay.PromoCodesApi.ArchitectureTests.CoreTests;

public class ServicesTests : CoreTestsBase
{
  private const string ServicesNamespace = "AutoPay.PromoCodesApi.Core.Services";

  [Fact]
  public void Services_Should_EndWithService()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .ResideInNamespace(ServicesNamespace)
      .Should()
      .HaveNameEndingWith("Service")
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Services_Should_BePublic()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .ResideInNamespace(ServicesNamespace)
      .Should()
      .BePublic()
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
}
