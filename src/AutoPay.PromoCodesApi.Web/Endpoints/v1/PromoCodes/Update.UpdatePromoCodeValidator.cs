namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

public class UpdatePromoCodeValidator : Validator<UpdatePromoCodeRequest>
{
    public UpdatePromoCodeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MinimumLength(2)
            .MaximumLength(DataSchemaConstants.PROMOCODE_NAME_LENGTH);
        
        RuleFor(x => x.PromoCodeId)
            .Must((args, promoCodeId) => args.Id == promoCodeId)
            .WithMessage("Route and body Ids must match; cannot update Id of an existing resource.");
    }
}
