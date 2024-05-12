namespace AutoPay.PromoCodesApi.UnitTests.UseCases.PromoCodes;

public class MarkAsInactiveHandlerTests
{
  private static readonly MarkAsInactiveCommand Command = new(1);
    
  private readonly MarkAsInactiveHandler _handler;
  private readonly IRepository<PromoCode> _repositoryMock;
    
  public MarkAsInactiveHandlerTests()
  {
    _repositoryMock = Substitute.For<IRepository<PromoCode>>();
    _handler = new MarkAsInactiveHandler(_repositoryMock);
  }
    
  [Fact]
  public async Task Handle_Should_ReturnSuccess_WhenPromoCodeIsExist()
  {
    _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
      .Returns(new PromoCode("name", "code", 10));
      
    var result = await _handler.Handle(Command, default);
    result.IsSuccess.Should().BeTrue();
  }

  [Fact]
  public async Task Handle_Should_ReturnError_WhenPromoCodeNotExist()
  {
    _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>()).ReturnsNull();
      
    var result = await _handler.Handle(Command, default);
    result.IsSuccess.Should().BeFalse();
    result.Status.Should().Be(ResultStatus.NotFound);
  }
}
