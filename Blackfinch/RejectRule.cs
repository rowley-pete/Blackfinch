namespace Blackfinch;

public class RejectRule(IApplicationRule? next) : ApplicationRule(next)
{
  public override bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    return false;
  }
}