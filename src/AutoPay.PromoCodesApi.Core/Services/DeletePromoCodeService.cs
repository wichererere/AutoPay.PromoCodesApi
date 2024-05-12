namespace AutoPay.PromoCodesApi.Core.Services;

public class DeletePromoCodeService(
    IRepository<PromoCode> _repository,
    IMediator _mediator,
    ILogger<DeletePromoCodeService> _logger) : IDeletePromoCodeService
{
    public async Task<Result> DeletePromoCode(int promoCodeId)
    {
        _logger.LogInformation("Deleting promo code {promoCodeId}", promoCodeId);
        PromoCode? aggregateToDelete = await _repository.GetByIdAsync(promoCodeId);
        if (aggregateToDelete == null) return Result.NotFound();

        await _repository.DeleteAsync(aggregateToDelete);
        
        var domainEvent = new PromoCodeDeletedEvent(promoCodeId);
        await _mediator.Publish(domainEvent);
        return Result.Success();
    }
}
