namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

public class UpdatePromoCodeResponse(PromoCodeRecord promoCode)
{
    public PromoCodeRecord PromoCode { get; set; } = promoCode;
}
