namespace AutoPay.PromoCodesApi.ArchitectureTests.CoreTests;

public class SpecificationsTests : CoreTestsBase
{
  [Fact]
  public void Specifications_Should_InheritSpecification()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That().ResideInNamespaceEndingWith(("Specifications"))
      .And().AreClasses()
      .Should().Inherit(typeof(Specification<>))
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Specifications_Should_EndWithSpec()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .Inherit(typeof(Specification<>))
      .Should()
      .HaveNameEndingWith("Spec")
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Specifications_Should_BePublicAndSealed()
  {
    var result = Types
      .InAssembly(CoreAssembly)
      .That()
      .Inherit(typeof(Specification<>))
      .Should()
      .BePublic()
      .And()
      .BeSealed()
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
}
