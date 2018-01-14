using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using BankApp2017.Models;

namespace BankApp2017.Views
{
    static class BankCLI
    {
        //returns a boolean value to signal that the user is logged in, and sends them on their way to the next menu.
        public static bool Login(Bank bank)
        {
            Console.Write("Please enter username: ");
            var username = Console.ReadLine();
            var password = Bank.EnterPassword();
            try
            {
                bank.CurrentUser = bank.AccountAuth(username, password);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid login.");
            }
            return false; 
        }

        //This ends the program since we have an application where there can only be one user logged in at a time. 
        public static void Logout()
        {
            Environment.Exit(0);
        }

        public static void CreateNewAccount(Bank bank)
        {
            Account account = new Account();
            Console.WriteLine("Let's get you started with a new account.");
            Console.WriteLine("Please enter a username for this account:");
            account.Username = Console.ReadLine();
            account.Password = Bank.EnterPassword();
            Console.WriteLine("What is your email?");
            account.Email = Console.ReadLine();
            Console.WriteLine("What amount of money would you like to start your account with?");
            account.Balance = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Here is your account info:");
            //TODO: print account info
            Console.WriteLine("Would you like to save it? (y/n)");
            if(Console.ReadKey().Key == (ConsoleKey.Y))
            {
                Console.WriteLine("\nAccount Created.");
                bank.AddNewBankMember(account);
                // TODO: Need to add here the addition of a transaction history item related to "account creation"
            }
            Console.WriteLine();
        }

        public static void GetBalance(Bank bank)
        {
            Console.Write("Current user balance: " + bank.CurrentUser.Balance + "\n");
        }

        public static void Deposit(Bank bank)
        {
            Console.WriteLine("How much money would you like to deposit?");
            try
            {
                decimal dep = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(bank.Deposit(bank.CurrentUser.Balance, dep));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Deposit Failed.");
            }
        }

        public static void Withdraw(Bank bank)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            try
            {
                decimal dep = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine(bank.Withdrawal(bank.CurrentUser.Balance, dep));
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Withdrawal Failed.");
            }
        }

        public static void TransactionHistory(Bank bank)
        {
            Console.WriteLine(bank.PrintTransactionHistory());
        }

        public static void DisplayAuthMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("(L)ogin: login to an existing account");
            Console.WriteLine("(S)ign Up: sign up for a new account");
            Console.WriteLine("(M)enu: clears console and prints menu options");
            Console.WriteLine("(Q)uit: quit the application");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Main Menu Options");
            Console.WriteLine("(M)enu: clears console print menu options again");
            Console.WriteLine("(B)alance: get the current user's balance");
            Console.WriteLine("(D)eposit: make a deposit into your account");
            Console.WriteLine("(W)ithdrawal: withdraw money from your account");
            Console.WriteLine("(H)istory: view history of bank or account records");
            Console.WriteLine("(L)ogout: Log out of the bank to let a new user use the bank");
            Console.WriteLine("(Q)uit: Quit the application");
        }

        public static void AuthenticateLoop(Bank bank)
        {
            Console.WriteLine("Welcome to AH Bank! Please log in or sign up for an account with us.");
            var authenticated = false;
            DisplayAuthMenu();

            while (authenticated != true)
            {
                Console.WriteLine("Please select an option from the menu:");

                var input = Console.ReadLine();
                if (input == null || input == "")
                {
                    input = " ";
                }
                input = input.ToUpper();
                switch (input[0])
                {
                    case 'L':
                        authenticated = Login(bank);
                        break;
                    case 'S':
                        CreateNewAccount(bank);
                        break;
                    case 'M':
                        Console.Clear();
                        break;
                    case 'Q':
                        Console.WriteLine("Thank you for visiting us, we hope you come back soon!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please select an option from above.");
                        break;
                }
                if(authenticated != true)
                    DisplayAuthMenu();

            }
        }

        public static void BankMenuLoop(Bank bank)
        {
            var logout = false;
            DisplayMenu();

            while (logout != true)
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
                        Console.Clear();
                        break;
                    case 'B':
                        GetBalance(bank);
                        break;
                    case 'D':
                        Console.WriteLine("Deposit");
                        Deposit(bank);
                        break;
                    case 'W':
                        Console.WriteLine("Withdrawal");
                        Withdraw(bank);
                        break;
                    case 'H':
                        Console.WriteLine("History");
                        TransactionHistory(bank);
                        break;
                    case 'L':
                        Console.WriteLine("Logging off.....");
                        logout = true;
                        break;
                    case 'Q':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Please select one of the options on the screen.");
                        break;
                }
                DisplayMenu();
            }
        }
    }
}
