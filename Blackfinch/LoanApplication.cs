namespace Blackfinch;

public record class LoadApplication(
  string ApplicantName,
  decimal LoanAmount,
  decimal AssetAmount,
  int CreditScore,
  bool IsSuccess)
{
  public decimal LoanToValue => LoanAmount / AssetAmount * 100;
}