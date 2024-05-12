namespace AutoPay.PromoCodesApi.Core.Interfaces;

public interface IDeletePromoCodeService
{
    public Task<Result> DeletePromoCode(int promoCodeId);
}
