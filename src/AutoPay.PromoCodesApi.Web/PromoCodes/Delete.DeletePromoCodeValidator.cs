namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public class DeletePromoCodeValidator : Validator<DeletePromoCodeRequest>
{
    public DeletePromoCodeValidator()
    {
        RuleFor(x => x.PromoCodeId)
            .GreaterThan(0);
    }
}
