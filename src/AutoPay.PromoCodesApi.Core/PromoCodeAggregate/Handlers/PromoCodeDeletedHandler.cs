namespace AutoPay.PromoCodesApi.Core.PromoCodeAggregate.Handlers;

internal class PromoCodeDeletedHandler(
    ILogger<PromoCodeDeletedHandler> logger) : INotificationHandler<PromoCodeDeletedEvent>
{
    public Task Handle(PromoCodeDeletedEvent domainEvent, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling promo code Deleted event for {promoCodeId}", domainEvent.PromoCodeId);

        return Task.CompletedTask;
    }
}
