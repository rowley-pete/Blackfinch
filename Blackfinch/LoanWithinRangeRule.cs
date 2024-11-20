namespace Blackfinch;

public class LoanWithinRangeRule : IApplicationRule
{
  public bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    if (loanAmount > 1500000 || loanAmount < 100000)
    {
      return false;
    }
    return null;
  }
}