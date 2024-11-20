namespace Blackfinch;

/// <summary>
/// If the value of the loan is less than £1 million and the LTV is less than 80%, the credit score of the applicant must be 800 or more
/// </summary>
public class LtvBetween60And79PercentRule : IApplicationRule
{
  public bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    decimal loanToValue = loanAmount / assetValue * 100;

    if (loanAmount < 1000000 && loanToValue >= 60 && loanToValue < 80) return creditScore >= 800;

    return null;
  }
}
