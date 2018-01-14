using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BankApp2017.Models;

namespace BankApp2017
{
    class Bank
    {
        List<Account> AccountList = new List<Account>();
        List<TransactionHistory> history = new List<TransactionHistory>();
        public Account CurrentUser = null;


        public void AddNewBankMember(Account account)
        {
            history.Add(new TransactionHistory(account.Username, DateTime.Now, "New Account", 0, account.Balance));
            AccountList.Add(account);
        }

        public Account AccountAuth(string username, string password) //please re-write this. 
        {
            try
            {
                return AccountList.First(item => item.Username.Equals(username) && item.Password.Equals(password)); // NEEDS EXCEPTION HANDLING
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("There are no users to log in with!");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("User not found.");
            }
            return null;
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
        public static string EnterPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            Console.WriteLine("Please enter password(characters allowed: a - z, A - Z, 0 - 9):");
            do
            {
                //TODO: add check to make sure that if the user presses the backspace key, it removes a character from the screen and the string
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Backspace)
                {
                    password.Remove(password.Length, 1);
                }
                password.Append(key.KeyChar);
                Console.Write("*");
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine(); //This places the curser on a new line after password typing pr you end up at the end of the ***** section.
            var temp = password.ToString();
            if(!r.IsMatch(temp))
            {
                Console.WriteLine("Please only use alphanumeric characters.");
            }
            temp.Trim('\r');
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(temp));
        }


        public decimal Withdrawal(decimal balance, decimal amount)
        {
            if (balance < -0.0001m || balance > 0.0001m)
            {
                balance -= amount;
            }
            history.Add(new TransactionHistory(CurrentUser.Username, DateTime.Now, "Withdrawal", Decimal.Negate(amount), balance));
            return balance;
        }

        public decimal Deposit(decimal balance, decimal amount)
        {
            balance += amount;
            history.Add(new TransactionHistory(CurrentUser.Username, DateTime.Now, "Deposit", Decimal.Negate(amount), balance));
            return balance;
        }

        public string PrintTransactionHistory()
        {
            StringBuilder build = new StringBuilder();
            build.Append(String.Format("{0, -17} {1, -17} {2, -17} {3, -17} {4, -17}\n", "Username", "Description", "Change", "Balance", "Time"));
            foreach (var trans in history.Where(item => item.Username.Equals(CurrentUser.Username)))
            {
                build.Append(String.Format("{0, -17} {1, -17} {2, -17} {3, -17} {4, 17}\n", trans.Username, trans.Description, FormatMoney(trans.Change), FormatMoney(trans.Balance), trans.Time)); 
            }
            return build.ToString();
        }

        public string FormatMoney(decimal money)
        {
            return String.Format("{0:C}", money);
        }

        public string PrintAccountUsers()
        {
            StringBuilder build = new StringBuilder();
            foreach (var item in AccountList)
            {
                build.Append(String.Format("Username is: {0} and email is: {1}", item.Username, item.Email));
            }
            return build.ToString();
        }
    }
}
