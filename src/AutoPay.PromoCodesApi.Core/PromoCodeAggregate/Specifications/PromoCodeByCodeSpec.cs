namespace AutoPay.PromoCodesApi.Core.PromoCodeAggregate.Specifications;

public sealed class PromoCodeByCodeSpec : Specification<PromoCode>
{
    public PromoCodeByCodeSpec(string code)
    {
        Query
            .Where(promoCode => promoCode.Code == code
                                && promoCode.IsActive);
    }
}
