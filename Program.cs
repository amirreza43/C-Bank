using System;

namespace C_Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            
            CBank.Bank NewBank = new CBank.Bank(){ BankName = "LNT" };
            CBank.User NewUser = new CBank.User(){ name = "John" };
            CBank.Savings NewUserSavings = new CBank.Savings(NewUser, NewBank);
            NewUserSavings.Deposit(100.00);

            NewUserSavings.Forecast(7);

            NewUserSavings.Withdraw(50.00);

            NewUserSavings.Withdraw(70.00);
            NewUserSavings.Withdraw(70.00);
            NewUserSavings.Withdraw(70.00);
            NewUserSavings.Deposit(70.00);

            NewUser.WriteLogs();
            NewUser.WriteToFile();

        }
    }
}
