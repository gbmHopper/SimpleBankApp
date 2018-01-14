using System;
using BankApp2017.Models;
using BankApp2017.Views;

namespace BankApp2017
{
    class Program
    {

         
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Bank bank = new Bank();

            Account account1 = new Account("amanda", "cGFzc3dvcmQ=", "test@test.com", 1000);
            Account account2 = new Account("alana", "cGFzc3dvcmQ=", "test@test.com", 2000);
            bank.AddNewBankMember(account1);
            bank.AddNewBankMember(account2);
            Console.WriteLine(bank.PrintAccountUsers());

            Console.WriteLine("Test users added");

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
