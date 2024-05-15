using AutoPay.PromoCodesApi.UseCases.PromoCodes.DecreaseMaxPossibleDownloads;

namespace AutoPay.PromoCodesApi.Web.v1.PromoCodes;

/// <summary>
/// Get a Promo Code by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Promo Code record.
/// </remarks>
public class GetById(IMediator _mediator)
    : Endpoint<GetPromoCodeByIdRequest, PromoCodeRecord>
{
    public override void Configure()
    {
        Get(GetPromoCodeByIdRequest.Route);
        AllowAnonymous();
        Version(1);
    }

    public override async Task HandleAsync(GetPromoCodeByIdRequest request,
        CancellationToken cancellationToken)
    {
      var command = new DecreaseMaxPossibleDownloadsCommand(request.PromoCodeId);
      var decreaseMaxPossibleDownloadsResult = await _mediator.Send(command, cancellationToken);

      if (decreaseMaxPossibleDownloadsResult.Status is ResultStatus.NotFound or ResultStatus.Invalid)
      {
        await SendNotFoundAsync(cancellationToken);
        return;
      }

      if (decreaseMaxPossibleDownloadsResult.IsSuccess)
      {
        var query = new GetPromoCodeQuery(request.PromoCodeId);

        var result = await _mediator.Send(query, cancellationToken);

        if (result.Status == ResultStatus.NotFound)
        {
          await SendNotFoundAsync(cancellationToken);
          return;
        }

        if (result.IsSuccess)
        {
          Response = new PromoCodeRecord(result.Value.Id, result.Value.Name, result.Value.Code, result.Value.MaxPossibleDownloads, result.Value.IsActive);
        }
      }
    }
}
