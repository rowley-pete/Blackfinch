namespace Blackfinch;

/// <summary>
/// If the value of the loan is less than £1 million and the LTV is less than 90%, the credit score of the applicant must be 900 or more
/// </summary>
public class LtvBetween80And89PercentRule : IApplicationRule
{
  public bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    decimal loanToValue = loanAmount / assetValue * 100;

    if (loanAmount < 1000000 && loanToValue >= 80 && loanToValue < 90) return creditScore >= 900;

    return null;
  }
}
