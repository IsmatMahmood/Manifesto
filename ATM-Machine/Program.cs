using System;

namespace ATM_Machine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var testAccount = Account.Parse(1234323, 2123, 680.00, 0);//initaling an account
        }
    }
}
