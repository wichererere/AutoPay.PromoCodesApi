namespace AutoPay.PromoCodesApi.UnitTests.UseCases.PromoCodes;

public class DecreaseMaxPossibleDownloadsCommandTests
{
  private static readonly DecreaseMaxPossibleDownloadsCommand Command = new(1);
    
  private readonly DecreaseMaxPossibleDownloadsHandler _handler;
  private readonly IRepository<PromoCode> _repositoryMock;
    
  public DecreaseMaxPossibleDownloadsCommandTests()
  {
    _repositoryMock = Substitute.For<IRepository<PromoCode>>();
    _handler = new DecreaseMaxPossibleDownloadsHandler(_repositoryMock);
  }
  
  private PromoCode CreatePromoCode(uint maxPossibleDownloads = 0)
  {
    return new PromoCode("testName", "testCode", maxPossibleDownloads);
  }

  [Fact]
  public async Task Handle_Should_ReturnNotFound_WhenPromoCodeIsNull()
  {
    _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
      .ReturnsNull();
    
    var result = await _handler.Handle(Command, default);
    
    result.IsSuccess.Should().BeFalse();
    result.Status.Should().Be(ResultStatus.NotFound);
  }
  
  [Fact]
  public async Task Handle_Should_ReturnNotFound_WhenPromoCodeIsInactive()
  {
    var promoCode = CreatePromoCode();
    promoCode.MarkAsInactive();
    
    _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())!
      .Returns(Task.FromResult(promoCode));
    
    var result = await _handler.Handle(Command, default);
    
    result.IsSuccess.Should().BeFalse();
    result.Status.Should().Be(ResultStatus.NotFound);
  }
  
  [Fact]
  public async Task Handle_Should_ReturnInvalid_WhenMaxPossibleDownloadsEqualsZero()
  {
    var promoCode = CreatePromoCode();
    
    _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())!
      .Returns(Task.FromResult(promoCode));
    
    var result = await _handler.Handle(Command, default);
    
    result.IsSuccess.Should().BeFalse();
    result.Status.Should().Be(ResultStatus.Invalid);
    result.ValidationErrors.Should().OnlyContain(x => x.ErrorMessage == PromoCodeErrors.PossibleDownloadsEqualZero);
  }
  
  [Fact]
  public async Task Handle_Should_ReturnSuccess_WhenDataIsValid()
  {
    var promoCode = CreatePromoCode(5);
    
    _repositoryMock.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())!
      .Returns(Task.FromResult(promoCode));
    
    var result = await _handler.Handle(Command, default);
    
    result.IsSuccess.Should().BeTrue();
    result.Status.Should().Be(ResultStatus.Ok);
  }
}
