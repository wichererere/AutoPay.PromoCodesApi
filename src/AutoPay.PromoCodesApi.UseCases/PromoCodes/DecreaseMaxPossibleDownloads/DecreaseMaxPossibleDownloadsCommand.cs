namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.DecreaseMaxPossibleDownloads;

/// <summary>
/// Decrease promo code max possible downloads by 1.
/// </summary>
/// <param name="PromoCodeId">Id of promo code</param>
public record DecreaseMaxPossibleDownloadsCommand(int PromoCodeId) : ICommand<Result>;
