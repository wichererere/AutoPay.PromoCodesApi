using AutoPay.PromoCodesApi.UseCases.PromoCodes.Delete;

namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

/// <summary>
/// Delete a Promo Code.
/// </summary>
/// <remarks>
/// Delete a Promo Code by providing a valid integer id.
/// </remarks>
public class Delete(IMediator _mediator)
    : Endpoint<DeletePromoCodeRequest>
{
    public override void Configure()
    {
        Delete(DeletePromoCodeRequest.Route);
        AllowAnonymous();
        Version(1);
    }

    public override async Task HandleAsync(
      DeletePromoCodeRequest request,
        CancellationToken cancellationToken)
    {
        var command = new DeletePromoCodeCommand(request.PromoCodeId);

        var result = await _mediator.Send(command, cancellationToken);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            await SendNoContentAsync(cancellationToken);
        }
    }
}
