namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public record DeletePromoCodeRequest
{
    public const string Route = "/PromoCodes/{PromoCodeId:int}";

    public static string BuildRoute(int promoCodeId) =>
        Route.Replace("{PromoCodeId:int}", promoCodeId.ToString());

    public int PromoCodeId { get; set; }
}
