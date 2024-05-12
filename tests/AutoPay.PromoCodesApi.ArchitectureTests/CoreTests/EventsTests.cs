namespace AutoPay.PromoCodesApi.ArchitectureTests.CoreTests;

public class EventsTests : CoreTestsBase
{
  [Fact]
  public void Events_Should_InheritDomainEventBase()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That().ResideInNamespaceEndingWith(("Events"))
      .And().AreClasses()
      .Should().Inherit(typeof(DomainEventBase))
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Events_Should_BeSealed()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .Inherit(typeof(DomainEventBase))
      .Should()
      .BeSealed()
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Events_ShouldNot_BePublic()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .Inherit(typeof(DomainEventBase))
      .ShouldNot()
      .BePublic()
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Events_Should_EndWithEvent()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .Inherit(typeof(DomainEventBase))
      .Should()
      .HaveNameEndingWith("Event")
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
}
