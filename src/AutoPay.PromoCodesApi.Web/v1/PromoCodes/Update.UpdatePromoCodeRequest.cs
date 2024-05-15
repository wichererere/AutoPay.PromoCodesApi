namespace AutoPay.PromoCodesApi.Web.v1.PromoCodes;

public class UpdatePromoCodeRequest
{
    public const string Route = "/PromoCodes/{PromoCodeId:int}";

    public static string BuildRoute(int promoCodeId) =>
        Route.Replace("{PromoCodeId:int}", promoCodeId.ToString());

    public int PromoCodeId { get; set; }

    [Required] public int Id { get; set; }
    [Required] public string? Name { get; set; }
}
