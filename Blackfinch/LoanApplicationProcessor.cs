namespace Blackfinch;

public class LoanApplicationProcessor
{
  private List<IApplicationRule> _applicationRules = [];

  public LoanApplicationProcessor()
  {
    _applicationRules.Add(new LoanWithinRangeRule());
    _applicationRules.Add(new HighValueLoanRule());
    _applicationRules.Add(new LtvLessThan60PercentRule());
    _applicationRules.Add(new LtvBetween60And79PercentRule());
    _applicationRules.Add(new LtvBetween80And89PercentRule());
    _applicationRules.Add(new LtvGreaterThan90Rule());
  }

  public bool? Process(
    decimal loanAmount,
    decimal assetValue,
    int creditScore)
  {
    foreach (var rule in _applicationRules)
    {
      var result = rule.Process(loanAmount, assetValue, creditScore);
      if (result.HasValue) return result.Value;
    }
    return false;
  }
}