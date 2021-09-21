using System;

namespace CBank
{
    public class Checking : User, IAccount{
        
        public double Balance;

       hasChecking=true;

        public bool IntialDeposit =true;
        public double deposit(double depositAmount){

            Balance+=depositAmount;

            if(IntialDeposit==true){
                userLogs.Add($"{name}, date, Initial Deposit, ${depositAmount}, Success, {Balance}");
                IntialDeposit=false;
                return Balance;
            }else{

                userLogs.Add($"{name}, date, Deposit, ${depositAmount}, Success, {Balance}");
                return Balance;
            }

        }

        public double withdraw(double withdrawalAmount){

            if(Balance>=withdrawalAmount){

                Balance-=withdrawalAmount;
                 userLogs.Add($"{name}, date, Withdrawl, ${withdrawalAmount}, Success, {Balance}");
                 return Balance;

            }else{

                userLogs.Add($"{name}, date, Withdrawl, ${withdrawalAmount}, Failure, {Balance}");
                Balance-=50.00;
                userLogs.Add($"{name}, date, Fee, $50, Success, {Balance}");
                return Balance;
            }
        }

    }
}