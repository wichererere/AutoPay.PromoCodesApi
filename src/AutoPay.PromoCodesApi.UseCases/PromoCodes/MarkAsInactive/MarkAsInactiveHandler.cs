namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.MarkAsInactive;

internal sealed class MarkAsInactiveHandler(IRepository<PromoCode> _repository)
    : ICommandHandler<MarkAsInactiveCommand, Result>
{
    public async Task<Result> Handle(MarkAsInactiveCommand request,
        CancellationToken cancellationToken)
    {
        var existingPromoCode = await _repository.GetByIdAsync(request.PromoCodeId, cancellationToken);
        if (existingPromoCode is not { IsActive: true })
        {
            return Result.NotFound();
        }

        existingPromoCode.MarkAsInactive();

        await _repository.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
