namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Update;

/// <summary>
/// Update a PromoCode.
/// </summary>
/// <param name="PromoCodeId">Id of promo code</param>
/// <param name="NewName">New name of promo code</param>
public record UpdatePromoCodeCommand(int PromoCodeId, string NewName) : ICommand<Result<PromoCodeDTO>>;
