namespace Blackfinch;

public abstract class ApplicationRule(IApplicationRule? next) : IApplicationRule
{
  public IApplicationRule? _next = next;

  public virtual bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    if (_next is not null) return _next.Process(loanAmount, assetValue, creditScore);

    return null;
  }
}