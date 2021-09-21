namespace CBank
{
    public interface IAccount
    {
        public double Deposit(double depositAmount);
        public double Withdraw(double withdrawalAmount);

    }
}