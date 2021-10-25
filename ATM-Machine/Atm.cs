using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    public interface IAtm
    {
        int Fund { get; set; }

        bool CheckForSufficentFunds(int withdrawlRequest);
        void WithdrawFunds(int withdrawlRequest);
    }

    public class Atm : IAtm
    {
        public int Fund { get; set; }

        public Atm (int fund)
        {
            this.Fund = fund;
        }

        public bool CheckForSufficentFunds (int withdrawlRequest)
        {
            if (withdrawlRequest > Fund)
            {
                Console.WriteLine("ATM_ERR");
                return false;
            }
            else
            {
                return true;
            }
        }

        public void WithdrawFunds (int withdrawlRequest)
        {
            if (CheckForSufficentFunds(withdrawlRequest) == true)
            {
                Fund -= withdrawlRequest;
            }
        }

    }
}
