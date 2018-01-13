using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BankApp2017.Views
{
    static class BankCLI
    {
        //returns a boolean value to signal that the user is logged in, and sends them on their way to the next menu.
        public static bool Login(Bank bank)
        {
            Console.Write("Please enter username: ");
            var username = Console.ReadLine();
            var password = EnterPassword();
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

        /**
         * NOTE ABOUT AUTHENTICATION FOR THIS APPLICATION: 
         * This program is currently using basic authentication (credentials are stored in base64 encoded fashion)
         * Keep in mind that THIS IS NOT A GOOD SECURITY PRACTICE as the level of authentication is weak, and very
         * very easy to crack. Typically businesses authenticate their users through a third party system like
         * OAuth or if in a corporate setting, their user list from their coporate domain using Windows authentication.
         * There are many ways to authenticate users, but for the sake of simplicity in my program I am taking an easier path. 
         * 
         * Authentication of users is always something that should be taken seriously in order to keep customer's data safe. 
         * 
         **/
        

        public static void CreateNewAccount(Bank bank)
        {
            Account account = new Account();
            Console.WriteLine("Let's get you started with a new account.");
            Console.WriteLine("Please enter a username for this account:");
            account.Username = Console.ReadLine();
            account.Password = EnterPassword();
            Console.WriteLine("What is your first name?");
            account.FirstName = Console.ReadLine();
            Console.WriteLine("What is your last name?");
            account.LastName = Console.ReadLine();
            Console.WriteLine("What is your email?");
            account.Email = Console.ReadLine();
            Console.WriteLine("What is your phone number?");
            account.Phone = Console.ReadLine();
            Console.WriteLine("What amount of money would you like to start your account with?");
            account.Balance = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Here is your account info:");
            //TODO: print account info
            Console.WriteLine("Would you like to save it? (y/n)");
            if(Console.ReadKey().Key == (ConsoleKey.Y))
            {
                Console.WriteLine("Account Created.");
                bank.AddNewBankMember(account);
                // TODO: Need to add here the addition of a transaction history item related to "account creation"
            }
            Console.WriteLine();
        }

        public static void DisplayAuthMenu()
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("(L)ogin: login to an existing account");
            Console.WriteLine("(S)ign Up: sign up for a new account");
            Console.WriteLine("(M)enu: Menu options and clear console");
            Console.WriteLine("(Q)uit: quit the application");
        }

        public static void DisplayMenu()
        {
            Console.WriteLine("Main Menu Options");
            Console.WriteLine("(M)enu: print menu options again and clear console");
            Console.WriteLine("(D)eposit: make a deposit into your account");
            Console.WriteLine("(W)ithdrawal: withdraw money from your account");
            Console.WriteLine("(H)istory: View history of bank or account records");
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
                        Console.WriteLine("Returning to Menu");
                        System.Threading.Thread.Sleep(3000);
                        Console.Clear();
                        DisplayAuthMenu();
                        break;
                    case 'Q':
                        Console.WriteLine("Thank you for visiting us, we hope you come back soon!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please select an option from above.");
                        break;
                }

            }
        }

        public static void BankMenuLoop(Bank bank)
        {
            var logout = false;
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
                        Console.WriteLine("Returning to Main Menu");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();
                        BankCLI.DisplayMenu();
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
            }
        }
    }
}
