namespace AutoPay.PromoCodesApi.ArchitectureTests.GenericTests;

public class DependencyTests
{
  private const string InfrastructureNamespace = "AutoPay.PromoCodesApi.Infrastructure";
  private const string UseCasesNamespace = "AutoPay.PromoCodesApi.UseCases";
  private const string WebNamespace = "AutoPay.PromoCodesApi.Web";

  [Fact]
  public void Core_Should_Not_HaveDependencyOnOtherProjects()
  {
    var assembly = typeof(Core.AssemblyReference).Assembly;

    string[] projects = [InfrastructureNamespace, UseCasesNamespace, WebNamespace];

    var result = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(projects)
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
  {
    var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

    string[] projects = [WebNamespace];

    var result = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(projects)
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
  
  [Fact]
  public void UseCases_Should_Not_HaveDependencyOnOtherProjects()
  {
    var assembly = typeof(UseCases.AssemblyReference).Assembly;

    string[] projects = [InfrastructureNamespace, UseCasesNamespace, WebNamespace];

    var result = Types
      .InAssembly(assembly)
      .ShouldNot()
      .HaveDependencyOnAll(projects)
      .GetResult();
    
    Assert.True(result.IsSuccessful);
  }
}
