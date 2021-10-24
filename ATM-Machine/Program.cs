using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace ATM_Machine
{
    class Program
    {
        private static object account;

        static void Main(string[] args)
        {
            
            string filepath = @"C:\Users\ismat\Documents\Code\Manifesto\ATM-Machine\TestData.txt";
            //string filepath2 = System.AppDomain.CurrentDomain.BaseDirectory;
            List<string> lines = File.ReadAllLines(filepath).ToList();
            var atm = Atm.Parse(Int32.Parse(lines[0]));
            lines.RemoveAt(0);
            List<string> transactions = lines;
            bool nextLineNewAccount = false;

            
            for (var i = 0; i < transactions.Count; i++)
            {
                transactions[i].Trim();
                if(transactions[i] == "")
                {
                    nextLineNewAccount = true;
                    continue;
                }     
                string[] transaction = transactions[i].Split(" ");
                if (nextLineNewAccount)
                {
                    var account = new Account(Int32.Parse(transaction[0]), Int32.Parse(transaction[1]));
                    try
                    {
                        account.CheckIfPinCorrect(Int32.Parse(transaction[2]));
                        nextLineNewAccount = false;
                        string[] balanceOverdraft = transactions[i+1].Split(" ");
                        account.SetBalanceAndOverdraft(Int32.Parse(balanceOverdraft[0]), Int32.Parse(balanceOverdraft[1]));
                        int nextRow = i+2;
                        while (transactions[nextRow].Trim() != "")
                        {
                            string[] action = transactions[nextRow].Split(" ");
                            switch (action[0])
                            {
                                case "B":
                                    nextRow++;
                                    account.GetBalance();
                                    break;
                                case "W":
                                    nextRow++;
                                    try
                                    {
                                        account.MakeWithdrawl(Int32.Parse(action[1]));
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e);
                                    }
                                    break;
                            }
                        }
                      //  Console.WriteLine(account.AccountNumber + " " + account.Pin + " " + account.Balance + " " + account.Overdraft);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }             
            }
            Console.WriteLine(atm.Fund);
           
        }
    }
}
