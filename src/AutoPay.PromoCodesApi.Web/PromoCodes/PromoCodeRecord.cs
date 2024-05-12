namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public record PromoCodeRecord(int Id, string Name, string Code, uint MaxPossibleDownloads, bool IsActive);
