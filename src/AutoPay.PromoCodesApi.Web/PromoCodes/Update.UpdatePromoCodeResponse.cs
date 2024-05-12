namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public class UpdatePromoCodeResponse(PromoCodeRecord promoCode)
{
    public PromoCodeRecord PromoCode { get; set; } = promoCode;
}
