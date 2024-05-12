namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Get;

/// <summary>
/// Get a single PromoCode.
/// </summary>
/// <param name="PromoCodeId">Id of promo code</param>
public record GetPromoCodeQuery(int PromoCodeId) : IQuery<Result<PromoCodeDTO>>;
