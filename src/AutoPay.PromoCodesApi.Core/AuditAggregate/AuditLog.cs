namespace AutoPay.PromoCodesApi.Core.AuditAggregate;

public class AuditLog(
  string entity,
  string state,
  string? primaryKey,
  string? oldValues,
  string? newValues,
  string? affectedColumns) : EntityBase
{
  public string Entity { get; init; } = Guard.Against.NullOrEmpty(entity, nameof(entity));
  public string State { get; init; } = Guard.Against.NullOrEmpty(state, nameof(state));
  public string? PrimaryKey { get; init; } = primaryKey;
  public string? OldValues { get; init; } = oldValues;
  public string? NewValues { get; init; } = newValues;
  public string? AffectedColumns { get; init; } = affectedColumns;
  public DateTime CreateOnUtc { get; init; } = DateTime.UtcNow;
}
