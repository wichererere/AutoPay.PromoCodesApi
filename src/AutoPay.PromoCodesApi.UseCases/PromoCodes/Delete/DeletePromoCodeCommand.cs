namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Delete;

/// <summary>
/// Delete a PromoCode.
/// </summary>
/// <param name="PromoCodeId">Id of promo code</param>
public record DeletePromoCodeCommand(int PromoCodeId) : ICommand<Result>;
