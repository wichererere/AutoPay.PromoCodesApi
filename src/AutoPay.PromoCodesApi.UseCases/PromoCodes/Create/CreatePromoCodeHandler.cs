namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Create;

internal sealed class CreatePromoCodeHandler(IRepository<PromoCode> _repository)
    : ICommandHandler<CreatePromoCodeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreatePromoCodeCommand request,
        CancellationToken cancellationToken)
    {
      var spec = new PromoCodeByCodeSpec(request.Code);
      
      if (await _repository.AnyAsync(spec, cancellationToken))
      {
        return Result.Invalid(new ValidationError(PromoCodeErrors.CodeNotUnique));
      }
      
      var newPromoCode = new PromoCode(request.Name, request.Code, request.MaxPossibleDownloads);

      var createdItem = await _repository.AddAsync(newPromoCode, cancellationToken);
      return createdItem.Id;
    }
}
