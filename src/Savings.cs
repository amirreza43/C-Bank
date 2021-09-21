using System;

namespace CBank 
{
    public class Savings : IAccount{
        public User Customer;

        public Bank Bank;
        public Savings(User newUser, Bank Bank){
            Customer = newUser;
            Customer.hasSavings = true;
            this.Bank = Bank;
        }

        public double Balance;

        public int FeeCounter = 0;

        public bool AccountStatus = true;

        public bool IntialDeposit = true;
        public DateTime localDate;

        public double Deposit(double depositAmount){
            localDate = DateTime.Now;
            if(AccountStatus){
                Balance+=depositAmount;
                if(IntialDeposit==true){
                    Bank.Users.Add(Customer);
                    Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Initial Deposit, ${depositAmount}, Success, Balance: ${Balance}");
                    IntialDeposit=false;
                    return Balance;
                }else{

                    Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Deposit, ${depositAmount}, Success, Balance: ${Balance}");
                    return Balance;
                }
            } else {
                    Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Deposit, ${depositAmount}, Failure, Balance: ${Balance}, Account is closed");
                    return Balance;
            }
        }

        public double Withdraw(double withdrawalAmount){
            localDate = DateTime.Now;
            if(AccountStatus){

                if(Balance>=withdrawalAmount){

                    Balance-=withdrawalAmount;
                    Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Withdrawal, ${withdrawalAmount}, Success, Balance: ${Balance}");
                    return Balance;

                }else{

                    Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Withdrawal, ${withdrawalAmount}, Failure, Balance: ${Balance}");
                    Balance-=50.00;
                    FeeCounter += 1;
                    Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Fee, $50, Success, {Balance}");
                    if(FeeCounter == 3){
                        Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Insufficient funds, Account closed.");
                        AccountStatus = false;
                    }
                    return Balance;
                }
            }else {
                Customer.userLogs.Add($"{Customer.name}, Savings, {localDate}, Withdrawal, ${withdrawalAmount}, Failure, Balance: ${Balance}, Account is closed");
                return Balance;
            }
        }

        public double Forecast(int years){
            // A = P(1 + r/n)^nt
            double ForcastedBalance = Balance*Math.Pow((1 + 0.012/12), (12*years));

            Customer.userLogs.Add($"Your balance for your savings account in {years} years will be {ForcastedBalance}");

            return ForcastedBalance;
        }

    }
}