namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

public class GetPromoCodeValidator : Validator<GetPromoCodeByIdRequest>
{
    public GetPromoCodeValidator()
    {
        RuleFor(x => x.PromoCodeId)
            .GreaterThan(0);
    }
}
