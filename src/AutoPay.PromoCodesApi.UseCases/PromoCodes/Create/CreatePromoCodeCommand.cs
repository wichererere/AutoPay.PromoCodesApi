namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Create;

/// <summary>
/// Create a new PromoCode.
/// </summary>
/// <param name="Name">Name of promo code</param>
/// <param name="Code">Unique promo code value</param>
/// <param name="MaxPossibleDownloads">Maximum number of possible downloads</param>
public record CreatePromoCodeCommand(string Name, string Code, uint MaxPossibleDownloads) : ICommand<Result<int>>;
