namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public class GetPromoCodeValidator : Validator<GetPromoCodeByIdRequest>
{
    public GetPromoCodeValidator()
    {
        RuleFor(x => x.PromoCodeId)
            .GreaterThan(0);
    }
}
