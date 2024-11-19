namespace Blackfinch;

public interface IApplicationRule
{
  bool? Process(decimal loanAmount, decimal assetValue, int creditScore);
}