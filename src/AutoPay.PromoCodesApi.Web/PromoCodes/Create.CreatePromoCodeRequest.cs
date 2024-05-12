namespace AutoPay.PromoCodesApi.Web.PromoCodes;

public class CreatePromoCodeRequest
{
    public const string Route = "/PromoCodes";

    [Required] public string? Name { get; set; }
    [Required] public string? Code { get; set; }
    [Required] public uint? MaxPossibleDownloads { get; set; }
}
