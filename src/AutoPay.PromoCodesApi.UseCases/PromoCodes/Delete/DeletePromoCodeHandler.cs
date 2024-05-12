namespace AutoPay.PromoCodesApi.UseCases.PromoCodes.Delete;

internal sealed class DeletePromoCodeHandler(IDeletePromoCodeService _deletePromoCodeService)
    : ICommandHandler<DeletePromoCodeCommand, Result>
{
    public async Task<Result> Handle(DeletePromoCodeCommand request, CancellationToken cancellationToken)
    {
        return await _deletePromoCodeService.DeletePromoCode(request.PromoCodeId);
    }
}
