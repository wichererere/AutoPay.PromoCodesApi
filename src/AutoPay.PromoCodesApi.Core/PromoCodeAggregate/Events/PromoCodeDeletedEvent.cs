namespace AutoPay.PromoCodesApi.Core.PromoCodeAggregate.Events;

internal sealed class PromoCodeDeletedEvent(int promoCodeId) : DomainEventBase
{
    public int PromoCodeId { get; } = promoCodeId;
}
