using System;

namespace CBank
{
    public class Checking : IAccount{
        public User Customer;

        public Bank Bank;
        public Checking(User NewUser, Bank Bank){
            Customer = NewUser;
            Customer.hasChecking = true;
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
                    Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Initial Deposit, ${depositAmount}, Success, Balance: ${Balance}, Account is open");
                    IntialDeposit=false;
                    return Balance;
                }else{

                    Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Deposit, ${depositAmount}, Success, Balance: ${Balance}, Account is open");
                    return Balance;
                }
            } else {
                    Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Deposit, ${depositAmount}, Failure, Balance: ${Balance}, Account is closed");
                    return Balance;
            }
        }

        public double Withdraw(double withdrawalAmount){
            localDate = DateTime.Now;
            if(AccountStatus){

                if(Balance>=withdrawalAmount){
                    Balance-=withdrawalAmount;
                    Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Withdrawal, ${withdrawalAmount}, Success, Balance: ${Balance}, Account is open");
                    return Balance;

                }else{

                    Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Withdrawal, ${withdrawalAmount}, Failure, Balance: ${Balance}, Account is open");
                    Balance-=50.00;
                    FeeCounter += 1;
                    Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Fee, $50, Success, Balance: ${Balance}, Account is open");
                    if(FeeCounter == 3){
                        Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Insufficient funds, ${withdrawalAmount}, Failure, Balance: ${Balance}, Account closed.");
                        AccountStatus = false;
                    }
                    return Balance;
                }
            }else {
                Customer.userLogs.Add($"{Customer.name}, Checking, {localDate}, Withdrawal, ${withdrawalAmount}, Failure, Balance: ${Balance}, Account is closed");
                return Balance;
            }
        }

    }
}