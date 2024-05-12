namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.List;

public interface IListPromoCodesQueryService
{
    Task<IEnumerable<PromoCodeDTO>> ListAsync();
}
