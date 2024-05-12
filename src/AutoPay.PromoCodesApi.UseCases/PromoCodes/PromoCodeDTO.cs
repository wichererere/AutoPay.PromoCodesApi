namespace AutoPay.PromoCodesApi.UseCases.PromoCodes;

public record PromoCodeDTO(int Id, string Name, string Code, uint MaxPossibleDownloads, bool IsActive);
