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
                AccountCLI.AuthenticateLoop(bank);
                Program.DisplayMenu();
                Program.ProcessLoop(bank);
            }
            
        }


        static void ProcessLoop(Bank bank)
        {
            var quit = false;
            while(quit != true)
            {
                var input = Console.ReadLine();
                if (input == null || input == "")
                {
                    input = " ";
                }
                input = input.ToUpper();

                switch (input[0])
                {
                    case 'M':
                        Console.WriteLine("Returning to Main Menu");
                        Program.DisplayMenu();
                        break;
                    case 'D':
                        Console.WriteLine("Deposit");
                        break;
                    case 'W':
                        Console.WriteLine("Withdrawal");
                        //Program.WithdrawMoney(new User("Amanda", "12345", 12000.00), bank);
                       
                        
                        break;
                    case 'H':
                        Console.WriteLine("History");
                        break;
                    case 'Q':
                        Console.WriteLine("Thank you for visiting the bank!");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Please select one of the options on the screen.");
                        break;
                }
            }
        }


        static void DisplayMenu()
        {
            Console.WriteLine("Main Menu Options");
            Console.WriteLine("(M)enu: print menu options again");
            Console.WriteLine("(D)eposit: make a deposit into your account");
            Console.WriteLine("(W)ithdrawal: withdraw money from your account");
            Console.WriteLine("(H)istory: View history of bank or account records");
            Console.WriteLine("(Q)uit: Quit the application");
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
