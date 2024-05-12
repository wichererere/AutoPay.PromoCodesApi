namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public class MarkAsInactiveValidator : Validator<MarkAsInactiveRequest>
{
    public MarkAsInactiveValidator()
    {
        RuleFor(x => x.PromoCodeId)
            .GreaterThan(0);
    }
}
