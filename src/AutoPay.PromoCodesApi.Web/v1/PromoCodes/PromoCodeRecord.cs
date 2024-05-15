namespace AutoPay.PromoCodesApi.Web.v1.PromoCodes;

public record PromoCodeRecord(int Id, string Name, string Code, uint MaxPossibleDownloads, bool IsActive);
