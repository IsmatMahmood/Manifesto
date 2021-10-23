using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public class Account
    {
        int AccountNumber { get; set; }
        int Pin { get; set; }
        double Balance { get; set; }
        double Overdraft { get; set; }
        
        public Account( int accountNo, int pin, double balance, double overdraft)
        {
            AccountNumber = accountNo;
            Pin = pin;
            Balance = balance;
            Overdraft = overdraft;
        }

        public bool CheckIfPinCorrect (int pin)
        {
            if ( Pin == pin)
            {
                return true;
            }
            else
            {
                return false;
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
                throw new InvalidOperationException("You do not have sufficient funds for this withdrawl amount!");
            }
            else
            {
                Balance -= withdrawlAmount;
                return Balance;
            }
        }
    }
}
