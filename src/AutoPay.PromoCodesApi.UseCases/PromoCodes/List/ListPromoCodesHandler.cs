namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.List;

internal sealed class ListPromoCodesHandler(IListPromoCodesQueryService _query)
    : IQueryHandler<ListPromoCodesQuery, Result<IEnumerable<PromoCodeDTO>>>
{
    public async Task<Result<IEnumerable<PromoCodeDTO>>> Handle(ListPromoCodesQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _query.ListAsync();

        return Result.Success(result);
    }
}
