namespace AutoPay.PromoCodesApi.UnitTests.UseCases.PromoCodes;

public class GetPromoCodeHandlerTests
{
  private static readonly GetPromoCodeQuery Query = new(1);
    
  private readonly GetPromoCodeHandler _handler;
  private readonly IReadRepository<PromoCode> _repositoryMock;
    
  public GetPromoCodeHandlerTests()
  {
    _repositoryMock = Substitute.For<IReadRepository<PromoCode>>();
    _handler = new GetPromoCodeHandler(_repositoryMock);
  }
  
  private PromoCode CreatePromoCode()
  {
    return new PromoCode("testName", "testCode", 10);
  }

  [Fact]
  public async Task Handle_Should_ReturnNotFound_WhenPromoCodeIsNull()
  {
    _repositoryMock.FirstOrDefaultAsync(Arg.Any<PromoCodeByIdSpec>(), Arg.Any<CancellationToken>())
      .ReturnsNull();

    var result = await _handler.Handle(Query, default);

    result.IsSuccess.Should().BeFalse();
    result.Status.Should().Be(ResultStatus.NotFound);
  }
  
  [Fact]
  public async Task Handle_Should_ReturnSuccess_WhenPromoCodeIsValid()
  {
    var promoCode = CreatePromoCode();
    _repositoryMock.FirstOrDefaultAsync(Arg.Any<PromoCodeByIdSpec>(), Arg.Any<CancellationToken>())
      .Returns(promoCode);

    var result = await _handler.Handle(Query, default);

    result.IsSuccess.Should().BeTrue();
    result.Status.Should().Be(ResultStatus.Ok);
    result.Value.Name.Should().Be(promoCode.Name);
    result.Value.Code.Should().Be(promoCode.Code);
    result.Value.MaxPossibleDownloads.Should().Be(promoCode.MaxPossibleDownloads);
  }
}
