namespace AutoPay.PromoCodesApi.UnitTests.Core.AuditLogTests;

public class Constructor
{
  private readonly string _testEntity = nameof(_testEntity);
  private readonly string _testState = nameof(_testState);
  private readonly string? _testPrimaryKey = nameof(_testPrimaryKey);
  private readonly string? _testOldValues = nameof(_testOldValues);
  private readonly string? _testNewValues = nameof(_testNewValues);
  private readonly string? _testAffectedColumns = nameof(_testAffectedColumns);
  
  [Fact]
  public void Constructor_Should_InitObject_WithGivenData()
  {
    var testAuditLog = new AuditLog(_testEntity, _testState, _testPrimaryKey, _testOldValues, _testNewValues, _testAffectedColumns);
    
    Assert.Equal(_testEntity, testAuditLog.Entity);
    Assert.Equal(_testState, testAuditLog.State);
    Assert.Equal(_testPrimaryKey, testAuditLog.PrimaryKey);
    Assert.Equal(_testOldValues, testAuditLog.OldValues);
    Assert.Equal(_testNewValues, testAuditLog.NewValues);
    Assert.Equal(_testAffectedColumns, testAuditLog.AffectedColumns);
  }
}
