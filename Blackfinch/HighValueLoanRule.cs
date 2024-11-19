namespace Blackfinch;

public class HighValueLoanRule(IApplicationRule next) : ApplicationRule(next)
{
  public override bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    decimal loanToValue = loanAmount / assetValue * 100;

    if (loanAmount >= 1000000) return loanToValue <= 60 && creditScore >= 950;

    return base.Process(loanAmount, assetValue, creditScore);
  }
}