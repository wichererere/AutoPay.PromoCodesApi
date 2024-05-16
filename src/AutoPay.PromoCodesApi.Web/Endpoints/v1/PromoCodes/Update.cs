using AutoPay.PromoCodesApi.UseCases.PromoCodes.Update;

namespace AutoPay.PromoCodesApi.Web.Endpoints.v1.PromoCodes;

/// <summary>
/// Update an existing Promo Code.
/// </summary>
/// <remarks>
/// Update an existing Promo Code by providing a fully defined replacement set of values.
/// </remarks>
public class Update(IMediator _mediator)
    : Endpoint<UpdatePromoCodeRequest>
{
    public override void Configure()
    {
        Put(UpdatePromoCodeRequest.Route);
        AllowAnonymous();
        Version(1);
    }

    public override async Task HandleAsync(
      UpdatePromoCodeRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdatePromoCodeCommand(request.Id, request.Name!), cancellationToken);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var query = new GetPromoCodeQuery(request.PromoCodeId);

        var queryResult = await _mediator.Send(query, cancellationToken);

        if (queryResult.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (queryResult.IsSuccess)
        {
            var dto = queryResult.Value;
            Response = new UpdatePromoCodeResponse(new PromoCodeRecord(dto.Id, dto.Name, dto.Code, dto.MaxPossibleDownloads, dto.IsActive));
        }
    }
}
