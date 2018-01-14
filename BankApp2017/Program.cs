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

            Console.WriteLine("Transaction History test");
            Console.WriteLine(bank.TransactionHistory());

            while(true) // This executes forever until the user decides to kill the app through Environment.Exit()
            {
                BankCLI.AuthenticateLoop(bank);
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
