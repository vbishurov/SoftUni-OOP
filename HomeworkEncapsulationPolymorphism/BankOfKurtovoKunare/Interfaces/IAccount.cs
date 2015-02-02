namespace BankOfKurtovoKunare.Interfaces
{
    public interface IAccount
    {
        ICustumer Custumer { get; }

        decimal Balance { get; }

        double InterestRate { get; }

        decimal CalculateInterest(int months);
    }
}
