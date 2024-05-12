namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.MarkAsInactive;

/// <summary>
/// Mark a PromoCode as inactive.
/// </summary>
/// <param name="PromoCodeId">Id of promo code</param>
public record MarkAsInactiveCommand(int PromoCodeId) : ICommand<Result>;
