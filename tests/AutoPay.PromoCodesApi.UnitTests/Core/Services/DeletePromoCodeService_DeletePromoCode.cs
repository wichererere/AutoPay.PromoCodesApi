namespace AutoPay.PromoCodesApi.UnitTests.Core.Services;

public class DeletePromoCodeService_DeletePromoCode
{
    private readonly IRepository<PromoCode> _repositoryMock = Substitute.For<IRepository<PromoCode>>();
    private readonly IMediator _mediatorMock = Substitute.For<IMediator>();
    private readonly ILogger<DeletePromoCodeService> _logger = Substitute.For<ILogger<DeletePromoCodeService>>();

    private readonly DeletePromoCodeService _service;

    public DeletePromoCodeService_DeletePromoCode()
    {
        _service = new DeletePromoCodeService(_repositoryMock, _mediatorMock, _logger);
    }
    
    private PromoCode CreatePromoCode()
    {
      return new PromoCode("testName", "testCode", 10);
    }
    
    [Fact]
    public async Task DeletePromoCode_Should_ReturnOk_WhenPromoCodeExist()
    {
      _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
        .Returns(CreatePromoCode());
      
      var result = await _service.DeletePromoCode(0);

      Assert.Equal(ResultStatus.Ok, result.Status);
    }

    [Fact]
    public async Task DeletePromoCode_Should_ReturnNotFound_WhenPromoCodeNotExist()
    {
        var result = await _service.DeletePromoCode(0);

        Assert.Equal(ResultStatus.NotFound, result.Status);
    }
}
