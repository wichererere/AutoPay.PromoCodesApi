namespace AutoPay.PromoCodesApi.Web.v1.PromoCodes;

public class UpdatePromoCodeResponse(PromoCodeRecord promoCode)
{
    public PromoCodeRecord PromoCode { get; set; } = promoCode;
}
