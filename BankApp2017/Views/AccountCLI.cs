using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace BankApp2017.Views
{
    static class AccountCLI
    {

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
        public static string EnterPassword()
        {
            StringBuilder password = new StringBuilder(); 
            ConsoleKeyInfo key;
            Console.WriteLine("Please enter a password(characters allowed: a - z, A - Z, 0 - 9):");
            do
            {
                //TODO: add check to make sure that if the user presses the backspace key, it removes a character from the screen and the string
                key = Console.ReadKey(true);
                // The if statement below is checking the key pressed that it is within the ranges of 0 - 9, A - Z, and a - z.
                if((((int)key.Key >= 48) && ((int)key.Key <= 57)) || (((int)key.Key >= 65) || ((int)key.Key <= 90)) || (((int)key.Key >= 97) && ((int)key.Key <= 122)))
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
            } while (key.Key != ConsoleKey.Enter);
            var temp = password.ToString();
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(temp));
        }

        public static void CreateNewAccount(Bank bank)
        {
            Account account = new Account();
            Console.WriteLine("Let's get you started with a new account.");
            Console.WriteLine("Please enter a username for this account:");
            account.Username = Console.ReadLine();
            account.Password = EnterPassword();
            Console.WriteLine("");
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
            Console.WriteLine("Account Created.");
            bank.AddNewBankMember(account);
        }

        public static void DisplayAuthMenu()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("(L)ogin: login to an existing account");
            Console.WriteLine("(S)ign Up: sign up for a new account");
            Console.WriteLine("(P)rint: print options");
            Console.WriteLine("(Q)uit: quit the application");
        }

        public static void AuthenticateLoop(Bank bank)
        {
            Console.WriteLine("Welcome to AH Bank! Please log in or sign up for an account with us.");
            DisplayAuthMenu();
            var authenticated = false;
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
                        Console.WriteLine("Login stuff here!");
                        authenticated = true;
                        break;
                    case 'S':
                        CreateNewAccount(bank);
                        break;
                    case 'P':
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
    }
}
