namespace AutoPay.PromoCodesApi.Infrastructure.Data.Config.Providers;

public record Provider(string Name, string Assembly) 
{
  public static Provider Sqlite = new (nameof(Sqlite), "AutoPay.PromoCodesApi.Sqlite");
  public static Provider SqlServer = new (nameof(SqlServer), "AutoPay.PromoCodesApi.SqlServer");
}
