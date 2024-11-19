using Blackfinch;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_If_Loan_Amount_Is_Too_High()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(1500001, 3000000, 950);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_If_Loan_Amount_Is_Too_Low()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(99999, 3000000, 950);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_For_More_Than_Million_Bad_Credit_Or_High_LTV()
    {
        var processor = new LoanApplicationProcessor();

        var badCredit = processor.Process(1400000, 3000000, 949);
        var ltvTooHigh = processor.Process(1400000, 2300000, 951);

        Assert.That(badCredit, Is.EqualTo(false));
        Assert.That(ltvTooHigh, Is.EqualTo(false));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Accept_For_More_Than_Million_Good_Credit_And_Low_LTV()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(1400000, 3000000, 950);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Accept_For_Less_Than_Million_LTV_60_Credit_Score_750()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(100000, 200000, 750);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_For_Less_Than_Million_LTV_60_Credit_Score_749()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(100000, 200000, 749);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Accept_For_Less_Than_Million_LTV_60_To_79_Credit_Score_800()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(150000, 200000, 800);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_For_Less_Than_Million_LTV_60_To_79_Credit_Score_799()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(150000, 200000, 799);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Accept_For_Less_Than_Million_LTV_80_To_89_Credit_Score_900()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(170000, 200000, 900);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_For_Less_Than_Million_LTV_80_To_89_Credit_Score_899()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(170000, 200000, 899);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void LoadApplicationProcessor_Should_Reject_For_Less_Than_Million_LTV_90_Plus_Credit_Score_900()
    {
        var processor = new LoanApplicationProcessor();

        var result = processor.Process(190000, 200000, 900);

        Assert.That(result, Is.EqualTo(false));
    }
}