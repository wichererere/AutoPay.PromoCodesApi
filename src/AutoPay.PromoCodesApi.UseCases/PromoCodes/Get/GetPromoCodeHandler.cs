namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Get;

internal sealed class GetPromoCodeHandler(IReadRepository<PromoCode> _repository)
    : IQueryHandler<GetPromoCodeQuery, Result<PromoCodeDTO>>
{
    public async Task<Result<PromoCodeDTO>> Handle(GetPromoCodeQuery request, CancellationToken cancellationToken)
    {
        var spec = new PromoCodeByIdSpec(request.PromoCodeId);
        var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        if (entity == null) return Result.NotFound();

        return new PromoCodeDTO(entity.Id, entity.Name, entity.Code, entity.MaxPossibleDownloads, entity.IsActive);
    }
}
