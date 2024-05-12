namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.DecreaseMaxPossibleDownloads;

internal sealed class DecreaseMaxPossibleDownloadsHandler(IRepository<PromoCode> _repository)
    : ICommandHandler<DecreaseMaxPossibleDownloadsCommand, Result>
{
    public async Task<Result> Handle(DecreaseMaxPossibleDownloadsCommand request,
        CancellationToken cancellationToken)
    {
        var existingPromoCode = await _repository.GetByIdAsync(request.PromoCodeId, cancellationToken);
        
        if (existingPromoCode is not { IsActive: true })
        {
            return Result.NotFound();
        }

        if (existingPromoCode.MaxPossibleDownloads == 0)
        {
          return Result.Invalid(new ValidationError(PromoCodeErrors.PossibleDownloadsEqualZero));
        }
        
        existingPromoCode.DecreaseMaxPossibleDownloads();
        await _repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
