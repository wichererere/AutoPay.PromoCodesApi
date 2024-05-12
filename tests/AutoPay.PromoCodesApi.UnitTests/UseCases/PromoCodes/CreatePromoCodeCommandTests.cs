namespace AutoPay.PromoCodesApi.UnitTests.UseCases.PromoCodes;

public class CreatePromoCodeCommandTests
{
    private static readonly CreatePromoCodeCommand Command = new("testName", "testCode", 10);
    
    private readonly CreatePromoCodeHandler _handler;
    private readonly IRepository<PromoCode> _repositoryMock;
    
    public CreatePromoCodeCommandTests()
    {
      _repositoryMock = Substitute.For<IRepository<PromoCode>>();
      _handler = new CreatePromoCodeHandler(_repositoryMock);
    }
    
    private PromoCode CreatePromoCode()
    {
      return new PromoCode(Command.Name, Command.Code, Command.MaxPossibleDownloads);
    }
    
    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenCodeIsUnique()
    {
      _repositoryMock.AddAsync(Arg.Any<PromoCode>(), Arg.Any<CancellationToken>())
        .Returns(Task.FromResult(CreatePromoCode()));
      
      _repositoryMock.AnyAsync(Arg.Any<PromoCodeByCodeSpec>(), Arg.Any<CancellationToken>())
        .Returns(false);
      
      var result = await _handler.Handle(Command, default);

      result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task Handle_Should_ReturnError_WhenCodeIsNotUnique()
    {
      _repositoryMock.AnyAsync(Arg.Any<PromoCodeByCodeSpec>(), Arg.Any<CancellationToken>())
        .Returns(true);
      
      var result = await _handler.Handle(Command, default);
      
      result.IsSuccess.Should().BeFalse();
      result.Status.Should().Be(ResultStatus.Invalid);
      result.ValidationErrors.Should().OnlyContain(x => x.ErrorMessage == PromoCodeErrors.CodeNotUnique);
    }
}
