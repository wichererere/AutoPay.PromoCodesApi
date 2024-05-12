namespace AutoPay.PromoCodesApi.Infrastructure.Data.Config;

public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
  public void Configure(EntityTypeBuilder<PromoCode> builder)
  {
    builder.Property(x => x.Id).ValueGeneratedOnAdd();
    
    builder.Property(x => x.Name).HasMaxLength(DataSchemaConstants.PROMOCODE_NAME_LENGTH).IsRequired();
    
    builder.Property(x => x.Code).HasMaxLength(DataSchemaConstants.PROMOCODE_CODE_LENGTH).IsRequired();

    builder.Property(x => x.MaxPossibleDownloads).IsRequired();
    
    builder.Property(x => x.IsActive).IsRequired();
    
    builder.HasIndex(x => x.Code).IsUnique().HasFilter("[IsActive] IS 1");

    // nie wiem czy wyświetlanie aktywnych/dostępnych kodów ma być filtrowane dla całej aplikacji, czy tylko na potrzeby wyświetlania
    //builder.HasQueryFilter(x => x.IsActive && x.MaxPossibleDownloads > 0);
  }
}
