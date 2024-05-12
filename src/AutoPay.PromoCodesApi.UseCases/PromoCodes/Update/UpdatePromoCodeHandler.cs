namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Update;

internal sealed class UpdatePromoCodeHandler(IRepository<PromoCode> _repository)
    : ICommandHandler<UpdatePromoCodeCommand, Result<PromoCodeDTO>>
{
    public async Task<Result<PromoCodeDTO>> Handle(UpdatePromoCodeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPromoCode = await _repository.GetByIdAsync(request.PromoCodeId, cancellationToken);
        if (existingPromoCode == null)
        {
            return Result.NotFound();
        }

        existingPromoCode.UpdateName(request.NewName);

        await _repository.SaveChangesAsync(cancellationToken);

        return Result.Success(new PromoCodeDTO(existingPromoCode.Id,
          existingPromoCode.Name, existingPromoCode.Code, existingPromoCode.MaxPossibleDownloads, existingPromoCode.IsActive));
    }
}
