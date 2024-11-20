namespace Blackfinch;

/// <summary>
/// If the value of the loan is less than £1 million and the LTV is 90% or more, the application must be declined
/// </summary>
public class LtvGreaterThan90Rule : IApplicationRule
{
  public bool? Process(decimal loanAmount, decimal assetValue, int creditScore)
  {
    decimal loanToValue = loanAmount / assetValue * 100;

    if (loanAmount < 1000000 && loanToValue >= 90) return false;

    return null;
  }
}