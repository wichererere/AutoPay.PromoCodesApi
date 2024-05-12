namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.List;

/// <summary>
/// List all PromoCodes.
/// </summary>
public record ListPromoCodesQuery : IQuery<Result<IEnumerable<PromoCodeDTO>>>;
