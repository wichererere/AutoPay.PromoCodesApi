using AutoPay.PromoCodesApi.UseCases.PromoCodes;
using AutoPay.PromoCodesApi.UseCases.PromoCodes.List;

namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

/// <summary>
/// List all Promo Codes
/// </summary>
/// <remarks>
/// List all promo codes - returns a PromoCodeListResponse containing the PromoCodes.
/// </remarks>
public class List(IMediator _mediator) : EndpointWithoutRequest<PromoCodeListResponse>
{
    public override void Configure()
    {
        Get(ListRequest.Route);
        AllowAnonymous();
        Version(1);
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        Result<IEnumerable<PromoCodeDTO>> result =
            await _mediator.Send(new ListPromoCodesQuery(), cancellationToken);

        if (result.IsSuccess)
        {
            Response = new PromoCodeListResponse
            {
                PromoCodes = result.Value.Select(c => new PromoCodeRecord(c.Id, c.Name, c.Code, c.MaxPossibleDownloads, c.IsActive)).ToList()
            };
        }
    }
}
