using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    class Atm
    {
        public int Fund { get; set; }

        public static Atm Parse(int fund)
        {
            var atm = new Atm();
            atm.Fund = fund;

            return atm;
        }
            public void SetFunds(int amount)
        {
            Fund = amount;
        }

        public bool CheckForSufficentFunds (int withdrawlRequest)
        {
            if (withdrawlRequest > Fund)
            {
                throw new Exception("ATM_ERR");
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
