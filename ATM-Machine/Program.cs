using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace ATM_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string filepath = @"C:\Users\ismat\Documents\Code\Manifesto\ATM-Machine\TestData.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            var atm = Atm.Parse(Int32.Parse(lines[0]));
            lines.RemoveAt(0);
            List<string> transactions = lines;
            bool nextLineNewAccount = false;
            int row = 0;

            while ( row < transactions.Count)
            {
                transactions[row].Trim();
                if (transactions[row] == "")
                {
                    nextLineNewAccount = true;
                    row++;
                    continue;
                }
                else
                {
                    string[] transaction = transactions[row].Split(" ");
                    if (nextLineNewAccount)
                    {
                        var account = new Account(Int32.Parse(transaction[0]), Int32.Parse(transaction[1]));
                        if (account.CheckIfPinCorrect(Int32.Parse(transaction[2])))
                        {
                            nextLineNewAccount = false;
                            string[] balanceOverdraft = transactions[row + 1].Split(" ");
                            account.SetBalanceAndOverdraft(Int32.Parse(balanceOverdraft[0]), Int32.Parse(balanceOverdraft[1]));
                            row += 2;
                            while (row < transactions.Count && transactions[row].Trim() != "")
                            {
                                string[] action = transactions[row].Split(" ");
                                switch (action[0])
                                {
                                    case "B":
                                        row++;
                                        account.GetBalance();
                                        break;
                                    case "W":
                                        row++;
                                        if (atm.CheckForSufficentFunds(Int32.Parse(action[1])))
                                        {
                                            atm.WithdrawFunds(Int32.Parse(action[1]));
                                            account.MakeWithdrawl(Int32.Parse(action[1]));
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
