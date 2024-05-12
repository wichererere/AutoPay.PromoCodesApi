namespace AutoPay.PromoCodesApi.ArchitectureTests.CoreTests;

public class HandlersTests : CoreTestsBase
{
  [Fact]
  public void Handlers_Should_ImplementINotificationHandler()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That().ResideInNamespaceEndingWith(("Handlers"))
      .And().AreClasses()
      .Should().ImplementInterface(typeof(INotificationHandler<>))
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Handlers_ShouldNot_BePublic()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .ImplementInterface(typeof(INotificationHandler<>))
      .ShouldNot()
      .BePublic()
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Handlers_Should_EndWithHandler()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .ImplementInterface(typeof(INotificationHandler<>))
      .Should()
      .HaveNameEndingWith("Handler")
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
}
