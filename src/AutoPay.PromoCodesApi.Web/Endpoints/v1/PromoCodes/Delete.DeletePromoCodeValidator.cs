namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

public class DeletePromoCodeValidator : Validator<DeletePromoCodeRequest>
{
    public DeletePromoCodeValidator()
    {
        RuleFor(x => x.PromoCodeId)
            .GreaterThan(0);
    }
}
