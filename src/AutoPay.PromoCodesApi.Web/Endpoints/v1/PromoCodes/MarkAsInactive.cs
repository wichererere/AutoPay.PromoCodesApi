using AutoPay.PromoCodesApi.UseCases.PromoCodes.MarkAsInactive;

namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

/// <summary>
/// Marks a Promo Code as inactive.
/// </summary>
/// <remarks>
/// Marks a Promo Code as inactive by providing a valid integer id.
/// </remarks>
public class MarkAsInactive(IMediator _mediator)
  : Endpoint<MarkAsInactiveRequest>
{
  public override void Configure()
  {
    Put(MarkAsInactiveRequest.Route);
    AllowAnonymous();
    Version(1);
  }

  public override async Task HandleAsync(
    MarkAsInactiveRequest request,
    CancellationToken cancellationToken)
  {
    var command = new MarkAsInactiveCommand(request.PromoCodeId);

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

