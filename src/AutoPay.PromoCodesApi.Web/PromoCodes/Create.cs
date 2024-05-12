namespace AutoPay.PromoCodesApi.Web.PromoCodes;

/// <summary>
/// Create a new Promo Code
/// </summary>
/// <remarks>
/// Creates a new Promo Code given a name, code and max possible downloads value.
/// </remarks>
public class Create(IMediator _mediator)
    : Endpoint<CreatePromoCodeRequest, PromoCodeRecord>
{
    public override void Configure()
    {
        Post(CreatePromoCodeRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Create a new Promo Code.";
            s.Description = "Create a new Promo Code. A valid name, code and max possible downloads are required.";
            s.ExampleRequest = new CreatePromoCodeRequest { Name = "Example name", Code = "ExampleCode", MaxPossibleDownloads = 10 };
        });
    }

    public override async Task HandleAsync(
      CreatePromoCodeRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreatePromoCodeCommand(request.Name!,
            request.Code!, request.MaxPossibleDownloads!.Value), cancellationToken);

        if (result.Status == ResultStatus.Invalid)
        {
          foreach (var resultValidationError in result.ValidationErrors)
          {
            AddError(resultValidationError.ErrorMessage);
          }
          
          await SendErrorsAsync(cancellation: cancellationToken);
        }
        
        if (result.IsSuccess)
        {
            Response = new PromoCodeRecord(result.Value, request.Name!, request.Code!, request.MaxPossibleDownloads!.Value, true);
        }
    }
}
