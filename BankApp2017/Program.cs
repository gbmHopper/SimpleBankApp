using System;
using BankApp2017.Views;

namespace BankApp2017
{
    class Program
    {

         
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Bank bank = new Bank();
            //Convert.toba

            Console.WriteLine("Testing Withdrawal");
            decimal money = 1000;
            Console.WriteLine("Balance: " + bank.FormatMoney(money));
            money = bank.Withdrawal(money, 20);
            Console.WriteLine("New balance: " + bank.FormatMoney(money));
            


            while(true) // This executes forever until the user decides to kill the app through Environment.Exit()
            {
                BankCLI.AuthenticateLoop(bank);
                BankCLI.DisplayMenu();
                BankCLI.BankMenuLoop(bank);
            }
            
        }


        



        static void WithdrawMoney(Bank bank)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Withdrawing...");
            //bank.Withdrawal(user, amount);
            //Console.WriteLine("New balance: " + user.balance);
        }

    }
}
