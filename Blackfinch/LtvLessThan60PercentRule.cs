namespace Blackfinch;

/// <summary>
/// If the value of the loan is less than £1 million and the LTV is less than 60%, the credit score of the applicant must be 750 or more
/// </summary>
public class LtvLessThan60PercentRule : IApplicationRule
{
  public bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    decimal loanToValue = loanAmount / assetValue * 100;

    if (loanAmount < 1000000 && loanToValue < 60) return creditScore >= 750;

    return null;
  }
}
