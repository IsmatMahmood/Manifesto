using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public interface IAccount
    {
        bool CheckIfPinCorrect(int pin);
        void SetBalanceAndOverdraft(int balance, int overdraft);
        int GetBalance();
        double MakeWithdrawl(int withdrawlAmount);
    }
    public class Account : IAccount
    {
        public int AccountNumber { get; set; }
        public int Pin { get; set; }
        public int? Balance { get; set; } = 0;
        public int? Overdraft { get; set; } = 0;
        
        public Account (int accountNo, int pin)
        {
            this.AccountNumber = accountNo;
            this.Pin = pin;
        }

        public bool CheckIfPinCorrect (int pin)
        {
            if ( this.Pin != pin)
            {
                throw new Exception("ACCOUNT_ERR");
            }
            else
            {
                return true;
            }   
        }

        public void SetBalanceAndOverdraft(int balance, int overdraft)
        {
            this.Balance = balance;
            this.Overdraft = overdraft;
        }
        
        public int GetBalance()
        {
            Console.WriteLine(this.Balance);
            return (int)this.Balance;
        }

        public double MakeWithdrawl(int withdrawlAmount)
        {
            if (withdrawlAmount > Balance + Overdraft)
            {
                throw new Exception("FUNDS_ERR");
            }
            else
            {
                this.Balance -= withdrawlAmount;
                Console.WriteLine(this.Balance);
                return (int)Balance;
            }
        }
    }
}
