namespace AutoPay.PromoCodesApi.Web.v1.PromoCodes;

public class MarkAsInactiveValidator : Validator<MarkAsInactiveRequest>
{
    public MarkAsInactiveValidator()
    {
        RuleFor(x => x.PromoCodeId)
            .GreaterThan(0);
    }
}
