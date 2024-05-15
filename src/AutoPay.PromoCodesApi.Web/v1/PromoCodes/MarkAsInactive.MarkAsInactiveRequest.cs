namespace AutoPay.PromoCodesApi.Web.v1.PromoCodes;

public record MarkAsInactiveRequest
{
  public const string Route = "/PromoCodes/{PromoCodeId:int}/MarkAsInactive";

  public static string BuildRoute(int promoCodeId) =>
    Route.Replace("{PromoCodeId:int}", promoCodeId.ToString());

  public int PromoCodeId { get; set; }
  
  [Required] public int Id { get; set; }
}
