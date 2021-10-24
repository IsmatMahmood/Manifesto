using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class Account
    {
        private int AccountNumber { get; set; }
        private int Pin { get; set; }
        private double Balance { get; set; }
        private double Overdraft { get; set; }
        
        public static Account Parse( int accountNo, int pin, double balance, double overdraft)
        {
            var account = new Account();
            account.AccountNumber = accountNo;
            account.Pin = pin;
            account.Balance = balance;
            account.Overdraft = overdraft;

            return account;
        }

        public bool CheckIfPinCorrect (int pin)
        {
            if ( Pin != pin)
            {
                throw new InvalidOperationException("ACCOUNT_ERR");
            }
            else
            {
                return true;
            }   
        }
        
        public double GetBalance()
        {
            return Balance;
        }

        public double MakeWithdrawl(int withdrawlAmount)
        {
            if (withdrawlAmount > Balance + Overdraft)
            {
                throw new InvalidOperationException("FUNDS_ERR");
            }
            else
            {
                Balance -= withdrawlAmount;
                return Balance;
            }
        }
    }
}
