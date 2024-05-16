namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

public class CreatePromoCodeValidator : Validator<CreatePromoCodeRequest>
{
    public CreatePromoCodeValidator()
    {
      RuleFor(x => x.Name)
        .NotEmpty()
        .WithMessage("Name is required.")
        .MinimumLength(2)
        .MaximumLength(DataSchemaConstants.PROMOCODE_NAME_LENGTH);
      
      RuleFor(x => x.Code)
        .NotEmpty()
        .WithMessage("Code is required.")
        .MinimumLength(2)
        .MaximumLength(DataSchemaConstants.PROMOCODE_CODE_LENGTH);
      
      RuleFor(x => x.MaxPossibleDownloads)
        .NotNull()
        .WithMessage("Max possible downloads is required.");
    }
}
