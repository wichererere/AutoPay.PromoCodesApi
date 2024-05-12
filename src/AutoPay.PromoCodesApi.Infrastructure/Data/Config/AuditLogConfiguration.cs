namespace AutoPay.PromoCodesApi.Infrastructure.Data.Config;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
  public void Configure(EntityTypeBuilder<AuditLog> builder)
  {
    builder.Property(x => x.Entity).IsUnicode(false);
    builder.Property(x => x.State).IsUnicode(false);
    builder.Property(x => x.PrimaryKey).IsUnicode(false);
    builder.Property(x => x.OldValues).IsUnicode(false);
    builder.Property(x => x.NewValues).IsUnicode(false);
    builder.Property(x => x.AffectedColumns).IsUnicode(false);
    builder.Property(x => x.CreateOnUtc);
  }
}
