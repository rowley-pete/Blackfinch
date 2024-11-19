// See https://aka.ms/new-console-template for more information
using Blackfinch;

List<LoadApplication> applications = [];

while (true)
{
  Console.WriteLine("Select an option:");
  Console.WriteLine("1. Start a new application");
  Console.WriteLine("2. View all applications");
  Console.WriteLine("3. Exit");
  string choice = Console.ReadLine() ?? string.Empty;

  switch (choice)
  {
    case "1":
      StartNewApplication();
      break;
    case "2":
      ViewAllApplications();
      break;
    case "3":
      return;
    default:
      Console.WriteLine("Invalid option, please try again.");
      break;
  }
}

void StartNewApplication()
{
  Console.WriteLine("Enter applicant name:");
  string applicantName = Console.ReadLine() ?? string.Empty;

  Console.WriteLine("Enter loan amount in GBP:");
  decimal loanAmount = decimal.Parse(Console.ReadLine());

  Console.WriteLine("Enter asset value in GBP:");
  decimal assetValue = decimal.Parse(Console.ReadLine());

  Console.WriteLine("Enter applicant credit score (1-999):");
  int creditScore = int.Parse(Console.ReadLine());

  var processor = new LoanApplicationProcessor();

  var application = new LoadApplication(
    applicantName,
    loanAmount,
    assetValue,
    creditScore,
    processor.Process(loanAmount, assetValue, creditScore) ?? false
  );

  applications.Add(application);

  Console.WriteLine($"Application for {applicantName}, with L2V: {application.LoanToValue}% and Credit Score: {application.CreditScore} {(application.IsSuccess ? "Approved" : "Declined")}");
  Console.WriteLine();
}

void ViewAllApplications()
{
  Console.WriteLine("--- Applications ---");
  foreach (var application in applications)
  {
    Console.WriteLine($"Applicant Name: {application.ApplicantName}");
    Console.WriteLine($"Loan Amount: {application.LoanAmount:C}");
    Console.WriteLine($"Asset Value: {application.AssetAmount:C}");
    Console.WriteLine($"Credit Score: {application.CreditScore}");
    Console.WriteLine($"Status: {(application.IsSuccess ? "Approved" : "Declined")}");
    Console.WriteLine($"Loan to Value (LTV): {application.LoanToValue:F2}%");
    Console.WriteLine();
  }
}