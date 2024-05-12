namespace AutoPay.PromoCodesApi.Core.PromoCodeAggregate.Specifications;

public sealed class PromoCodeByIdSpec : Specification<PromoCode>
{
    public PromoCodeByIdSpec(int promoCodeId)
    {
      Query
        .Where(promoCode => promoCode.Id == promoCodeId
                            && promoCode.IsActive);
    }
}
