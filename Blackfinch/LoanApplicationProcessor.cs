namespace Blackfinch;

public class LoanApplicationProcessor
{
  private IApplicationRule applicationRules;

  public LoanApplicationProcessor()
  {
    applicationRules =
      new LoanWithinRangeRule(
        new HighValueLoanRule(
          new LtvLessThan60PercentRule(
            new LtvBetween60And79PercentRule(
              new LtvBetween80And89PercentRule(
                new RejectRule(null))))));
  }

  public bool? Process(
    decimal loanAmount,
    decimal assetValue,
    int creditScore)
  {
    return applicationRules.Process(loanAmount, assetValue, creditScore);
  }
}