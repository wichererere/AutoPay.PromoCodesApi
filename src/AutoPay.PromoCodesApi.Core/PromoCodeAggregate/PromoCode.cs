namespace AutoPay.PromoCodesApi.Core.PromoCodeAggregate;

public class PromoCode(string name, string code, uint maxPossibleDownloads) : EntityBase, IAggregateRoot
{
    public string Name { get; private set; } = Guard.Against.NullOrEmpty(name, nameof(name));
    public string Code { get; private set; } = Guard.Against.NullOrEmpty(code, nameof(code));
    public uint MaxPossibleDownloads { get; private set; } = maxPossibleDownloads;
    public bool IsActive { get; private set; } = true;
    
    public void UpdateName(string newName)
    {
        Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
    }

    public void MarkAsInactive()
    {
      IsActive = false;
    }

    public void DecreaseMaxPossibleDownloads()
    {
      Guard.Against.Zero(MaxPossibleDownloads);
      MaxPossibleDownloads -= 1;
    }
}
