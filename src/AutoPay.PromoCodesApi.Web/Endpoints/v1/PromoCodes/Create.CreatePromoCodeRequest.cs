namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

public class CreatePromoCodeRequest
{
    public const string Route = "/PromoCodes";

    [Required] public string? Name { get; set; }
    [Required] public string? Code { get; set; }
    [Required] public uint? MaxPossibleDownloads { get; set; }
}
